    private Boolean IsLastPay()
    {
       if (!string.IsNullOrEmpty(LastPayDate))
    {
       string lpd;
    }
       if(Parameters.TryGetValue("Last Pay Date", out lpd))
    {
       if(DateTime.Parse(lpd) > new DateTime(2018,05,24))
           return true;
       else
           return false;
    }
    }
    return false;
    }
