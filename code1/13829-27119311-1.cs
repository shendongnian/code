    public object GetInstance(string strFullyQualifiedName)
    {         
         Type t = Type.GetType(strFullyQualifiedName); 
         return  Activator.CreateInstance(t);         
    }
