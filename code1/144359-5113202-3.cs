    private static string GetControllerNameRegex()
    {
    	var controllerNamesRegex = new StringBuilder();
        List<string> controllers = GetControllerNames();
        controllers.ForEach(s =>
                controllerNamesRegex.AppendFormat("{0}|", s));
        return controllerNamesRegex.ToString().TrimEnd('|');
    }
    private static List<Type> GetSubClasses<T>()
    {
        return Assembly.GetCallingAssembly().GetTypes().Where(type => 
               type.IsSubclassOf(typeof(T))).ToList();
    }
    public List<string> GetControllerNames()
    {
        List<string> controllerNames = new List<string>();
        GetSubClasses<Controller>().ForEach(type => controllerNames.Add(type.Name));
        return controllerNames;
    }
