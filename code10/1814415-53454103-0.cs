    public static bool IsGenericList(object value)
            {
                if (value == null)
                    return false;
    
                try
                {
                    var val =  value as IList;
                    if (val == null)
                        return false;
    
                    if ((typeof(BaseConversion)).IsAssignableFrom(val.GetType().GetGenericArguments()[0]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
