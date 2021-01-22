    void DoStuff()
    {
        System.Console.WriteLine( SomeMethod((int)5) );
        System.Console.WriteLine( GetTypeName<int>() );
    }
    string SomeMethod(object someParameter)
    {
        return string.Format("Some text {0}", someParameter.ToString());
    }
    
    string GetTypeName<T>()
    {
    	return (typeof (T)).FullName;
    }
