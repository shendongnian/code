    public static dynamic ExecuteMethod(object obj, dynamic p)
    {
	    var frame =
            new StackTrace().GetFrames()
                            .Skip(1) // Skip the 'ExecuteMethod'
                            .First(x => x.GetMethod().DeclaringType.Namespace != "System.Dynamic");
	    return frame.GetMethod().Name;
    }
