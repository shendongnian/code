    internal class HeaderInfo {
 
        internal readonly bool IsRequestRestricted;
        internal readonly bool IsResponseRestricted;
        internal readonly HeaderParser Parser;
 
        //
        // Note that the HeaderName field is not always valid, and should not
        // be used after initialization. In particular, the HeaderInfo returned
        // for an unknown header will not have the correct header name.
        //
 
        internal readonly string HeaderName;
        internal readonly bool AllowMultiValues;
        ...
        }
           
