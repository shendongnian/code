        public static bool TryCast<T>(ref T t, object o)
        {
            if (!(o is T))
            {
                return false;
            }
            t = (T)o;
            return true;
        }
