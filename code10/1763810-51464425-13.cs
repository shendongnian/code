    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media.Imaging;
    namespace WpfApp1
    {
	class Class2 : INotifyPropertyChanged
	{
		private string _IMAGE_PATH;
		public string IMAGE_PATH
		{
			get { return _IMAGE_PATH; }
			set
			{
				_IMAGE_PATH = value;
				NotifyPropertyChanged();
				img = new BitmapImage(
				    new Uri("pack://application:,,,/Images/" + value));
			}
		}
		private BitmapImage _img;
		public BitmapImage img
		{
			get
			{
				return _img;
			}
			set
			{
				_img = value;
				NotifyPropertyChanged();
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		private string _value;
		public string value
		{
			get { return _value; }
			set { _value = value; NotifyPropertyChanged(); }
		}
	}
    }
