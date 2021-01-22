    MyObject myObject = new MyObject();
    Type type = myObject.GetType();
    if(typeof(YourBaseObject).IsAssignableFrom(type))
    {  
       //Do your casting.
       YourBaseObject baseobject = (YourBaseObject)myObject;
    }  
