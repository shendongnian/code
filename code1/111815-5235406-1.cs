    public static T? Parse<T>(this string text) where T: struct
        {
            object o = null;
            try { 
                var ttype = typeof(T);
                if (ttype.IsEnum)
                {
                    T n = default(T);
                    if (Enum.TryParse<T>(text, true, out n))
                        return n;
                }
                else
                o = Convert.ChangeType(text, ttype); 
            }
            catch { }
            if (o == null)
                return new Nullable<T>();
            return new Nullable<T>((T)o);
        }
