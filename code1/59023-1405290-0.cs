	/// <summary>
		/// From BReusable
		/// </summary>
		/// <param name="dtp"></param>
		/// <param name="dataSource"></param>
		/// <param name="valueMember"></param>
		/// <remarks>With help from Dan Hanan at http://blogs.interknowlogy.com/danhanan/archive/2007/01/21/10847.aspx</remarks>
		public static void BindNullableValue(this DateTimePicker dateTimePicker, BindingSource dataSource, String valueMember,bool showCheckBox)
		{
			var binding = new Binding("Value", dataSource, valueMember, true);
			//OBJECT PROPERTY --> CONTROL VALUE
			binding.Format += new ConvertEventHandler((sender, e) =>
			{
				Binding b = sender as Binding;
				
				if (b != null)
				{
					DateTimePicker dtp = (binding.Control as DateTimePicker);
					if (dtp != null)
					{
						if (e.Value == null)
						{
							dtp.ShowCheckBox = showCheckBox;
							dtp.Checked = false;
							// have to set e.Value to SOMETHING, since it's coming in as NULL
							// if i set to DateTime.Today, and that's DIFFERENT than the control's current
							// value, then it triggers a CHANGE to the value, which CHECKS the box (not ok)
							// the trick - set e.Value to whatever value the control currently has. 
							// This does NOT cause a CHANGE, and the checkbox stays OFF.
							e.Value = dtp.Value;
						}
						else
						{
							dtp.ShowCheckBox = showCheckBox;
							dtp.Checked = true;
							// leave e.Value unchanged - it's not null, so the DTP is fine with it.
						}
					}
				}
			});
			// CONTROL VALUE --> OBJECT PROPERTY
			binding.Parse += new ConvertEventHandler((sender, e) =>
			{
				// e.value is the formatted value coming from the control. 
				// we change it to be the value we want to stuff in the object.
				Binding b = sender as Binding;
				if (b != null)
				{
					DateTimePicker dtp = (b.Control as DateTimePicker);
					if (dtp != null)
					{
						if (dtp.Checked == false)
						{
							dtp.ShowCheckBox = showCheckBox;
							dtp.Checked = false;
							e.Value = (Nullable<DateTime>)null;
						}
						else
						{
							DateTime val = Convert.ToDateTime(e.Value);
							e.Value = val;
						}
					}
				}
			});
			dateTimePicker.DataBindings.Add(binding);
		}
