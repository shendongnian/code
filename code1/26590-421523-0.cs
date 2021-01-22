    public partial class DaysOfWeekPicker : UserControl
	{
		public event EventHandler ValueChanged;
		private DaysOfWeek myValue;
		[DefaultValue (0)]
		public DaysOfWeek Value
		{
			get { return myValue; }
			set { myValue = value; RefreshData (); }
		}
		public DaysOfWeekPicker ()
		{
			InitializeComponent ();
		}
		private void DayOfWeekClick (object sender, EventArgs e)
		{
			if (Object.ReferenceEquals (sender, g_l_Sunday))
			{
				this.Value = this.Value ^ DaysOfWeek.Sunday;
			}
			else if (Object.ReferenceEquals (sender, g_l_Monday))
			{
				this.Value = this.Value ^ DaysOfWeek.Monday;
			}
			else if (Object.ReferenceEquals (sender, g_l_Tuesday))
			{
				this.Value = this.Value ^ DaysOfWeek.Tuesday;
			}
			else if (Object.ReferenceEquals (sender, g_l_Wednesday))
			{
				this.Value = this.Value ^ DaysOfWeek.Wednesday;
			}
			else if (Object.ReferenceEquals (sender, g_l_Thursday))
			{
				this.Value = this.Value ^ DaysOfWeek.Thursday;
			}
			else if (Object.ReferenceEquals (sender, g_l_Friday))
			{
				this.Value = this.Value ^ DaysOfWeek.Friday;
			}
			else if (Object.ReferenceEquals (sender, g_l_Saturday))
			{
				this.Value = this.Value ^ DaysOfWeek.Saturday;
			}
		}
		private void RefreshData ()
		{
			SetLabelDisplay (g_l_Sunday, (this.Value & DaysOfWeek.Sunday) == DaysOfWeek.Sunday);
			SetLabelDisplay (g_l_Monday, (this.Value & DaysOfWeek.Monday) == DaysOfWeek.Monday);
			SetLabelDisplay (g_l_Tuesday, (this.Value & DaysOfWeek.Tuesday) == DaysOfWeek.Tuesday);
			SetLabelDisplay (g_l_Wednesday, (this.Value & DaysOfWeek.Wednesday) == DaysOfWeek.Wednesday);
			SetLabelDisplay (g_l_Thursday, (this.Value & DaysOfWeek.Thursday) == DaysOfWeek.Thursday);
			SetLabelDisplay (g_l_Friday, (this.Value & DaysOfWeek.Friday) == DaysOfWeek.Friday);
			SetLabelDisplay (g_l_Saturday, (this.Value & DaysOfWeek.Saturday) == DaysOfWeek.Saturday);
			if (this.ValueChanged != null) this.ValueChanged (this, EventArgs.Empty);
		}
		private void SetLabelDisplay (LinkLabel label, bool enabled)
		{
			if (enabled)
			{
				label.BackColor = Color.Black;
				label.ForeColor = Color.White;
			}
			else
			{
				label.BackColor = Color.White;
				label.ForeColor = Color.Black;
			}
		}
	}
