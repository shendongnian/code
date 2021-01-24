    using System;
    using System.Collections.Generic;
    using ...
    class Manager
    {
        Dictionary<Type, Func<IUserControl>> constructorCache = new Dictionary<Type, Func<IUserControl>>();
        public void Add(Type userControlType, Func<IUserControl> construct)
        {
            // do some checking for existing if you want
            constructorCache[type] = construct;
        }
       
        
        public void Get(Type userControlType)
        {
            // check for existing
            return constructorCache[type];
        }
    }
