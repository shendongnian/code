    public object _selectedItemInFilter;
		public object SelectedItemInFilter
		{
			get
			{
				return _selectedItemInFilter;
			}
			set
			{
				if (_selectedItemInFilter != value)
				{
					_selectedItemInFilter = value;
					ComboBoxChanged();
					Console.WriteLine("SelectedItem: {0}", SelectedItemInFilter); // outputs the right item name
					NotifyPropertyChanged("SelectedItemInFilter");
				}
			}
		}
		private void ComboBoxChanged()
		{
			if (((ComboBoxItem)SelectedItemInFilter).Content.ToString() == "Car")
			{
				Console.WriteLine("Do something with car...");
			}
			else
			{
				Console.WriteLine("Is not Car...");
			}
		}
