    public static void AssertNotNull<T>(string name, T val)
        where T : class
        {
            if (val == null)
                throw new ArgumentNullException(String.Format("{0} must not be null", name));
        }
