    DateTime myDateTime = DateTime.Parse("24 May 2009 02:19:00");
    
    myDateTime = myDateTime + new TimeSpan(1, 1, 1);
    myDateTime = myDateTime - new TimeSpan(1, 1, 1);
    myDateTime += new TimeSpan(1, 1, 1);
    myDateTime -= new TimeSpan(1, 1, 1);
