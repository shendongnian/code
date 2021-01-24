    using System;
    using ...
    class Manager
    {
        Dictionary<Type, Func<IUserControl>> factoryCache = new Dictionary<Type, Func<IUserControl>>();
        public void Add(Type userControlType, Func<IUserControl> construct)
        {
            // do some checking for existing if you want
            factoryCache[type] = construct;
        }
       
        
        public void Get(Type userControlType)
        {
            // check for existing
            return factoryCache[type]
        }
    }
