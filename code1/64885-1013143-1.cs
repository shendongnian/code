    class Program
    {
        [DllImport("the_name_of_the_delphi_library.dll")]
        public static extern double GetCPUSpeed();
        static void Main(string[] args)
        {
            double cpuSpeed = GetCPUSpeed();
            Console.WriteLine("CPU speed: {0}", cpuSpeed);
        }
    }
