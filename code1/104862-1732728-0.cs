    Label myLabel = new Label();
    string s = "text";
    string value = "new value";
    System.Reflection.PropertyInfo[] properties = myLabel.GetType().GetProperties();
    foreach (System.Reflection.PropertyInfo p in properties) 
    {
        if(p.Name == s)
        {
             p.SetValue(myLabel, value, null);
        }
    }
