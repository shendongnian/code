    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    namespace WpfApp1
    {
	class VM : INotifyPropertyChanged
	{
		public VM()
		{
			Items = new ObservableCollection<Class2>();
		}
		private ObservableCollection<Class2> _Items;
		public ObservableCollection<Class2> Items
		{
			get { return _Items; }
			set { _Items = value; NotifyPropertyChanged(); }
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
    }
