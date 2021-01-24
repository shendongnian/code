        List<object> listOfObject = new List<object>();
        listOfObject.Add(new Demo()); //Demo Implements IInterface
        listOfObject.Add(new Demo2());//Demo2 doesn't Implement IInterface
        //this will have all possible types
        List<Type> listOfAllType = new List<Type>();
        //this will have type of those class, which implement interface
        List<Type> listOfInterfaceType = new List<Type>();
        //this will have objet of those class, which implement interface.
        List<object> listOfInterfaceObject = new List<object>();
        foreach(object obj in listOfObject)
        {
            Type type = obj.GetType();
            if (!listOfAllType.Contains(type))
                listOfAllType.Add(obj.GetType());
            try
            {
                IInterface testInstance = (IInterface)obj;
                listOfInterfaceType.Add(obj.GetType());
                listOfInterfaceObject.Add(obj);
            }
            catch
            {
                //if a class is not implementing an interface,
                // it's object will not successfully converted into Interface,
                // and thus will throw an exception.
            }
        }
