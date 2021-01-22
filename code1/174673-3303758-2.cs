    public void LoadTourList()
    {
      AllTours = ( from t in Database.Instance.Tours
        select new TourViewModel( t ) ).ToList();
    
      RaisePropertyChanged( "AllTours" );
    }
