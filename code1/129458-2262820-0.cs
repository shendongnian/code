    AmountComments = r.Attribute("AmountComments").ToInt32();
    public static class LinqUtils
    {
        public static int Int32(this XAttribute attribute)
        {
            return System.Int32.Parse(attribute.Value);
        }
    }
