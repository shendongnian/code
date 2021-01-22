    public class Utility
    {
        public static string Config1 { get { return "Fourty Two"; } }
        public int Config2 { get; set; }
        public static int Negate(int x) { return -x; }
        private Utility() { }
        /// Get an instance of Utility     
        public static Utility GetUtility()
        {
            return new Utility();
        }
    }   
