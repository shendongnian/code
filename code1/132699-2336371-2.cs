    public static class Extensions
    {
        public static bool IsNull(this object o)
        {
            if (o == null || DBNull.Value.Equals(o))
                return true;
            else
                return false;
        }
    }
