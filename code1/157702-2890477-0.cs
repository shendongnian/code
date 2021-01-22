     List<IFoo> items = new List<IFoo>();
    //Iterate through all types
    foreach (Type type in Assembly.GetExecutingAssembly.GetTypes) {
        //Check the type is public and not abstract
        if (!type.IsPublic | type.IsAbstract)
            continue;
        //Check if it implements the interface IFoo
        if (typeof(IFoo).IsAssignableFrom(type)) {
            
            //Create an instance of the class
            //If the constructor has arguments put them after "type" like so: 
            //Activator.CreateInstance(type, arg1, arg2, arg3, etc...)
            IFoo foo = (IFoo)Activator.CreateInstance(type);
            //Add the instance to your collection
            items.Add(foo);
	    }
    }
