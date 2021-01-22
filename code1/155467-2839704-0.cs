     dynamic v = new Foo();
     Type t = v.GetType();
     System.Reflection.PropertyInfo[] pInfo =  t.GetProperties();
     if (Array.Find<System.Reflection.PropertyInfo>(pInfo, p => { return p.Name == "PropName"; }).    GetValue(v,  null) != null))
     {
         //PropName initialized
     } 
