	void ProfileView_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		IsEmailValid();
		OnPropertyChanged("IsValid"); // <== this one is important!
	}
