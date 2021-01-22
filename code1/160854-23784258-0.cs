        public static bool TryParse<T>(this String str, out T parsedValue)
        {
            try
            {
                parsedValue = (T)Convert.ChangeType(str, typeof(T));
                return true;
            }
            catch { parsedValue = default(T); return false; }
        }
