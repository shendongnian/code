    public static class CardViewExt
    {
        public static string ToStringFormatted(this CardView c)
        {
            if (c == null)
                return "null card";
            return String.Format("-------\nexternal id: {0} \ntitle: {1}\n-------", c.ExternalCardID, c.Title);
        }
    }
