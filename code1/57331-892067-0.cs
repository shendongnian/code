    public static bool operator ==(a a, b b)
        {
            //Need this check or we can't do obj == null in our Equals implementation
            if (((Object)a) == null)
            {
                return false;
            }
            else
            {
                return a.Equals(b);
            }
        }
