    public static class BoolExtensions
    {
        public static bool And<TR, TC>(this IEnumerable<Func<TR, TC, bool>> statements, TR value, TC criteria)
        {
            foreach (var statement in statements)
            {
                if (!statement.Invoke(value, criteria))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool Or<TR, TC>(this IEnumerable<Func<TR, TC, bool>> statements, TR value, TC criteria)
        {
            foreach (var statement in statements)
            {
                if (statement.Invoke(value, criteria))
                {
                    return true;
                }
            }
            return false;
        }
    }
