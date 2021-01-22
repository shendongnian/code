        public void GetIDForPassedInObject<T>(T obj)
        {
            var type = obj.GetType();
            var propsWithAttrib = type.GetProperties().Where(prop => prop.GetCustomAttributes(typeof(IdentifierAttribute), false).Count() > 0);
            var prop = propsWithAttrib.FirstOrDefault();
            if (prop != null)
            {
                var value = prop.GetValue(obj, null);
            } 
        } 
