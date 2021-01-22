    public T GetValueOrNull<T>(string strElementNameToSearchFor, IFormatProvider provider = null ) 
        {
            IFormatProvider theProvider = provider == null ? Provider : provider;
            XElement elm = GetUniqueXElement(strElementNameToSearchFor);
  
            if (elm == null)
            {
                object o =  Activator.CreateInstance(typeof(T));
                return (T)o; 
            }
            else
            {
                try
                {
                    Type type = typeof(T);
                    if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == typeof(Nullable<>).GetGenericTypeDefinition())
                    {
                        type = Nullable.GetUnderlyingType(type);
                    }
                    return (T)Convert.ChangeType(elm.Value, type, theProvider); 
                }
                catch (Exception)
                {
                    object o = Activator.CreateInstance(typeof(T));
                    return (T)o; 
                }
            }
        }
