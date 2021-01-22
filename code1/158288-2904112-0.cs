        static void Main(string[] args)
        {
            HardwareInterfaceType type = default(HardwareInterfaceType);
            Console.WriteLine(type.ToString());
            type = HardwareInterfaceType.Gpib;
            Console.WriteLine(type.ToString());
            Console.ReadLine();
        }
        public enum HardwareInterfaceType
        {
            Gpib = 1,
            Vxi = 2,
            GpibVxi = 3,
        }
        //output
        0
        Gpib
