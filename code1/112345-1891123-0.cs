    class Program
    {
        static void Main(string[] args)
        {
        }
        public void method1()
        {
            bool? safeFileNames = null;
            if (safeFileNames != null)
            {
                SafeFileNames = Convert.ToBoolean(safeFileNames.Value);
            }
            else
            {
                SafeFileNames = false;
            }
        }
        public void method2()
        {
            bool? safeFileNames = null;
            SafeFileNames = safeFileNames != null && Convert.ToBoolean(safeFileNames.Value);
        }
        public static bool SafeFileNames { get; set; }
    }
