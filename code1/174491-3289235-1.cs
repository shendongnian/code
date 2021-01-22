        public object GetIDForPassedInObject(T obj)
        {
            var prop = typeof(T).GetProperties()
                .FirstOrDefault(prop => prop.GetCustomAttributes(typeof(IdentifierAttribute), false).Count() ==1);
            object ret = prop !=null ?  prop.GetValue(obj, null) : null;
            
            return ret;
        }  
