    private void AddZebraClick(object sender, RoutedEventArgs e)
	{
		Examples.Add("Zebra");
		NotifyPropertyChanged("Examples");
	}
	private void AddYoYoClick(object sender, RoutedEventArgs e)
	{
		Examples.Add("YoYo");
		NotifyPropertyChanged("Examples");
	}
