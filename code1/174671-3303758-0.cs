    public ObservableCollection<Tour> Tours
    {
      get
      {
        if ( _tours == null )
        {
          _tours = new ObservableCollection<Tour>();
          ThreadPool.QueueUserWorkItem(LoadTours);
        }
        return _tours;
      }
    }
    
    private void LoadTours(object o)
    {
      var start = DateTime.Now;
      //simlate lots of work 
      Thread.Sleep(5000);
      _tours = IsoStore.Deserialize<ObservableCollection<Tour>>( ToursFilename ) ??  new ObservableCollection<Tour>();
      Debug.WriteLine( "Deserialize time: " + DateTime.Now.Subtract( start ).ToString() );
      RaisePropertyChanged("Tours");
    }
