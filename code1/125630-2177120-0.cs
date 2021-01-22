    public static class Extensions
    {
        public static string ToCustomString(this decimal d)
        {
            int i = (int)d;
            if (i == d)
                return i.ToString();
            return d.ToString("#.00");
        }
    }
