    DateTime myDate=Convert.ToDateTime("22.08.2010");
    
    String newFormat=myDate.Day.ToString()+"/"+myDate.Month.ToString()+"/"+myDate.Year.ToString();
    
    DateTime newDateFormat=Convert.ToDateTime(newFormat);
