    public static class AgeExtender
    {
        public static int GetAge(this DateTime dt)
        {
            int d = int.Parse(dt.ToString("yyyyMMdd"));
            int t = int.Parse(DateTime.Today.ToString("yyyyMMdd"));
            return (t-d)/10000;
        }
    }
