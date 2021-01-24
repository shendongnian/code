    public class CommonData
    {
        public static string o = string.Empty;
        public static void SetData(string s)
        {
            String[] vals = s.Split(';');
            o = "X=" + vals[0] + "  Y=" + vals[1] + "  Z=" + vals[2];
        }
    }
