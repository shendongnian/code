        public static bool Equals(this object x, params object[] y)
        {
            for (int i = 0; i < y.Length; i++)
            {
                if (!object.Equals(x, y[i]))
                    return false;
            }
            return true;
        }
