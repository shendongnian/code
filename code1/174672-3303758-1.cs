    private void DatabasePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if(e.PropertyName == "Tours")
      {
        LoadTourList();
      }
    }
