    static void Main(string[] args)
            {
                int val = 20000;
                string currency = string.Format("Total: {0}",ToKdisplay (val));
            }
    
            private static string ToKdisplay(int val)
            {
                string result = "";
                result = val > 1000 ? string.Format("${0}K", val / 1000) : string.Format("${0}", val);
                return result;
            }
