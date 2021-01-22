    int loginId = MySession.Current.LoginId;
    
    string property1 = MySession.Current.Property1;
    MySession.Current.Property1 = newValue;
    
    DateTime myDate = MySession.Current.MyDate;
    MySession.Current.MyDate = DateTime.Now;
