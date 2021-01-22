     public static void VerifyNotNullOrEmpty<T>(this IEnumerable<T> theIEnumerable,
                                        string theIEnumerableName,
                                        string theVerifyingPosition)
    {
        string errMsg = theVerifyingPosition + " " + theIEnumerableName;
        if (theIEnumerable == null)
        {
            errMsg +=  @" is null";
            Debug.Assert(false);
            throw new ApplicationException(errMsg);
        }
        else if (theIEnumerable.Count() == 0)
        {
            errMsg +=  @" is empty";
            Debug.Assert(false);
            throw new ApplicationException(errMsg);
        }
    }
