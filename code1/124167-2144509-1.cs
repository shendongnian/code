    public static Nullable<T> GetQueryString<T>(string key) where T : struct, IConvertible
            {
                T result = default(T);
    
                if (String.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]) == false)
                {
                    string value = HttpContext.Current.Request.QueryString[key];
    
                    try
                    {
                        result = (T)Convert.ChangeType(value, typeof(T));  
                    }
                    catch
                    {
                        //Could not convert.  Pass back default value...
                        result = default(T);
                    }
                }
    
                return result;
            }
