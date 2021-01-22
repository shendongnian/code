    public static class Ext
    {
        public static class String
        {
            public static int ToInt32(string val)
            {
                return Int32.Parse(val);
            }
        }
    }
    //Then call:
    Ext.String.ToInt32("32");
