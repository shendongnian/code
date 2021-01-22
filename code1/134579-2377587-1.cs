    public static string getPath() 
    {
        string fullname;
        string myAppPath;
        fullname = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        myAppPath = System.IO.Path.GetDirectoryName(fullname);
        myAppPath = myAppPath.Replace("file:\\", "");
        return myAppPath;
    }
