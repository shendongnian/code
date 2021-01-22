     // String to DateTime
     String MyString;
     MyString = "1999-09-01 21:34 PM";
     //MyString = "1999-09-01 21:34 p.m.";  //Depends on your regional settings
    
     DateTime MyDateTime;
     MyDateTime = new DateTime();
     MyDateTime = DateTime.ParseExact(MyString, "yyyy-MM-dd HH:mm tt",
                                      null);
