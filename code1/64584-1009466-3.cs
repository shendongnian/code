     // String to DateTime
     String MyString;
     MyString = "Jun 17 2009, 03:37 pm";
    
     DateTime MyDateTime;
     MyDateTime = new DateTime();
     MyDateTime = DateTime.ParseExact(MyString, "MMM dd YYYY, HH:mm tt", null);
