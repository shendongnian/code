    public static String toStringNullAllowed(this Object inputObject)
    {
       if (inputObject == null) { return null; }
       return inputObject.ToString();
    }
