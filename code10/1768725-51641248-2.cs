    //Method declaration 
    static bool IsTypeClass<T>(T value)
    {
       Type ParamType = typeof(T);
        if(T.GetType() == "TypeClass")
        {
            //Is a TypeClass object
            return true;
        }
        //Is not a TypeClass Object
        return false;
    }
