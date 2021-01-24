    public DateTime GetDateTime()
    {
        var inputDate = DateTime.ParseExact(this.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
        var inputTime = TimeSpan.Parse(this.Time);
        DateTime datetime = inputDate + inputTime;
        return datetime;
    }
