    static string AssocQueryString(AssocStr association, string extension)
    {
        public const int S_OK = 0;
        public const int S_FALSE = 1;
        uint length = 0;
        uint ret = AssocQueryString(AssocF.None, association, extension, null, null, ref length);
        if (ret != S_FALSE)
        {
            throw new InvalidOperationException("Could not determine associated string");
        }
        var sb = new StringBuilder((int)length); // (length-1) will probably work too as the marshaller adds null termination
        ret = AssocQueryString(AssocF.None, association, extension, null, sb, ref length);
        if (ret != S_OK)
        {
            throw new InvalidOperationException("Could not determine associated string"); 
        }
        return sb.ToString();
    }
