    using System;
    class ComClass
    {
        public bool CallFunction(arg1, arg2)
        {
            Type ComType;
            object ComObject;
    
            ComType = Type.GetTypeFromProgID("Registered.ComClass");
            // Create an instance of your COM Registered Object.
            ComObject = Activator.CreateInstance(ComType);
    
            object[] args = new object[2];
            args[0] = arg1;
            args[1] = arg2;
    
            // Call the Method and cast return to whatever it should be.
            return (bool)ComType.InvokeMember("MethodToCall", BindingFlags.InvokeMethod, null, ComObject, args))
        }
    }
