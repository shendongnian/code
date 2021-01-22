    DateTime dtm = DateTime.Now;
    if (dtm.Minute < 30)
    {
         dtm = dtm.AddMinutes(dtm.Minute * -1);
    }
    else
    {    
         dtm = dtm.AddMinutes(60 - dtm.Minute);
    }
    dtm = dtm.AddSeconds(dtm.Second * -1);
