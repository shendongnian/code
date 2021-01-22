    foreach(object o in nodes)
    {
        Type t = o.GetType();
    
        PropertyInfo[] pi = t.GetProperties(); 
    
        foreach (PropertyInfo p in pi)
        {
            if (p.Name=="Checked" && !o.GetValue("Checked"))
                System.out.println("awesome!");
        }
    }
