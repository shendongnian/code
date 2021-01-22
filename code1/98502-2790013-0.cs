        public static T CheckForNull<T>(object primary, T Default)
        {
            try
            {
                if (primary != null && !(primary is DBNull))
                    return (T)Convert.ChangeType(primary, typeof(T));
                else if (Default.GetType() == typeof(T))
                    return Default;
            }
            catch (Exception e)
            {
                throw new Exception("C:CFN.1 - " + e.Message + "Unexpected object type of " + primary.GetType().ToString() + " instead of " + typeof(T).ToString());
            }
            return default(T);
        }
