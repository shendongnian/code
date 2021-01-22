    namespace ExtensionMethods
    {
        public static class JSONHelper
        {
            public static ToJSON(this object obj)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(obj);
            }
            public static string ToJSON(this object obj, int recursionDepth)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.RecursionLimit = recursionDepth;
                return serializer.Serialize(obj);
            }
        }
    }
