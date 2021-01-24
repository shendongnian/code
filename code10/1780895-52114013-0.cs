    class Program
    {
        static void Main(string[] args)
        {
            
            WezKomponent("Win32_DiskDrive", "Model");
           
            Console.ReadKey();
        }
        private static void WezKomponent(string ass, string sax)
        {
            ManagementObjectSearcher wez = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + ass);
            StreamWriter SW = new StreamWriter(@"HDD.txt");
            foreach (ManagementObject pie in wez.Get())
               
            
            {
                
                Console.WriteLine(Convert.ToString(pie[sax]));
                SW.WriteLine(Convert.ToString(pie[sax]));
            }
            SW.Close();
        }
        
