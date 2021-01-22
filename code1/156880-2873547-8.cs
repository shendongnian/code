     public static void VerifyNotNullOrEmpty<T>(this IEnumerable<T> items,
                                        string name,
                                        string verifyingPosition)
    {
        if (items== null)
        {
            Debug.Assert(false);
            throw new NullReferenceException(string.Format("{0} {1} is null.", verifyingPosition, name));
        }
        else if ( !items.Any() )
        {
            Debug.Assert(false);
            // you probably want to use a better (custom?) exception than this - EmptyEnumerableException or similar?
            throw new ApplicationException(string.Format("{0} {1} is empty.", verifyingPosition, name));
        }
    }
