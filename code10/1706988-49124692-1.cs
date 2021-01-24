    string concatedstr=String. Empty ;
    for (int i = 1; i <= 5; i++) {
 
        string varName = "Name";
        Type t = typeof(Car); 
        PropertyInfo prop = t.GetProperty(varName + i.ToString()); 
        if (null != prop) 
            concatedstr+= prop.GetValue(this, null);
        }
    }
