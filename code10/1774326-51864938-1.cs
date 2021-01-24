     private  DateTimeDateTime _matchCalendarDate, _matchCalendarD = DateTime.Now;
        
        public DateTime MatchCalendarDate
        {
           get
           {
              var date = _matchCalendarDate.Value.ToString("dd-MM-yyyy");
    
              var dt = DateTime.ParseExact(date, "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        
              var c = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        
              return c;
           }
           set
           {
              _matchCalendarDate = value;
              OnPropertyChanged();
           }
        }
