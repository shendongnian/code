            if (map.Exists(key))
            {
                if (typeof(T) == typeof(int))
                {
                    value = (T)(object)map.GetInt(key);
                }
                value = default(T); // this is just a nicety because I am lazy, 
                                    // add real code here.
            }
        } 
