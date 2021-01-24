    DateTime expireDate = new DateTime(2018, 7, 30, 22, 0, 0); //for testing
    DateTime tomorrowAt0910 = DateTime.Now.Date.AddHours(9).AddMinutes(10);
    
    if (expireDate.Date < DateTime.Now.Date)
    {
        tomorrowAt0910.AddDays(1);
    }
