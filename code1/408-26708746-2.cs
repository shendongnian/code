    public object GetInstance(string strNamesapace)
    {         
         Type t = Type.GetType(strNamesapace); 
         return  Activator.CreateInstance(t);         
    }
