    public DateTime GetDateTime()
    {
      DateTime dateTime = DateTime.MinValue;
      if(!String.IsNullOrEmpty(Date) && !String.IsNullOrEmpty(Time))
           dateTime= DateTime.Parse(string.Format("{0} {1}", Date, Time));
      return dateTime;
    }
