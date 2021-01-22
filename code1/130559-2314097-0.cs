    public abstract class BaseClass : VeryBaseClass
    {
        private static string GetInheritedClassName
        {
            get
            {
                // Get the current Stack
                StackTrace currentStack = new StackTrace();
                MethodBase method = currentStack.GetFrame(1).GetMethod();
    
                // 1st frame should be the constructor calling
                if (method.Name != ".ctor")
                    return null;
    
                method = currentStack.GetFrame(2).GetMethod();
    
                // 2nd frame should be the constructor of the inherited class
                if (method.Name != ".ctor")
                    return null;
    
                // return the type of the inherited class
                return method.ReflectedType.Name;
            }
        }
    
        public BaseClass(MyObject myObject) :
            base(GetInheritedClassName, myObject)
        {
            
        }
    }
