    public DateTime GetDateTime()
    {
        var inputDate = DateTime.ParseExact(this.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
        var inputTime = TimeSpan.ParseExact(this.Time,"HH:mm", CultureInfo.InvariantCulture);
        DateTime datetime = inputDate + inputTime;
        return datetime;
    }
