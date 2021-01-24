    string selectedClass;
    string selectedFunction;
            
    public object GetClassInstanceFromName(string name) 
    {
        return Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName, name);
    }
    public string InVokefunctionByName(object instance,string methName)
    {
        return instance.GetType().GetMethod(methName).Invoke(instance, null) as string;     
    }
 
    //Overload if you want to continue to use your enum
    public object GetClassInstanceFromName(ClassTypes name)
    {
        return 
         Activator.CreateInstance(Assembly.GetExecutingAssembly().FullName,
         "class" +name.ToString());
    }
