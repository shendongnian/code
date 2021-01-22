        public static Maybe<T> GetQueryString<T>(string key) where T : IConvertible
        {
            if (String.IsNullOrEmpty(HttpContext.Current.Request.QueryString[key]) == false)
            {
                string value = HttpContext.Current.Request.QueryString[key];
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    //Could not convert.  Pass back default value...
                    return new Maybe<T>();
                }
            }
            return new Maybe<T>();
        }
