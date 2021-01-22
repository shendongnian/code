    DateTime dt = new DateTime(2009, 6, 22, 10, 0, 0);  //Date 6/22/2009 10:00:00 AM
    string time = dt.ToString("hh:mm tt");              //Output: 10:00 AM
    time = dt.ToString("HH:mm tt");                     //Output: 10:00 AM
    dt = new DateTime(2009, 6, 22, 22, 0, 0);           //Date 6/22/2009 10:00:00 PM
    time = dt.ToString("hh:mm tt");                     //Output: 10:00 PM
    time = dt.ToString("HH:mm tt");                     //Output: 22:00 PM
