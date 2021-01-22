    using System;
    using System.Management;
    using System.IO;
    class Program
    {
        public static string computerName = "localhost";
        // a central place to store the info, 
        public static string inventFile = @"\\Wdstorage\public\install\Inventfile.txt";
        static void Main(string[] args)
        {
            try
            {
                FileStream fileStream = new FileStream(inventFile, FileMode.Append);
                if (File.Exists(inventFile))
                {
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.Write("Added: " + DateTime.Now.ToString());
                        ManagementScope scope = new ManagementScope(@"\\" + computerName + @"\root\cimv2");
                        scope.Connect();
                        ObjectQuery query = new ObjectQuery("Select * From Win32_SystemEnclosure");
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                        ManagementObjectCollection objColl = searcher.Get();
                        foreach (ManagementObject o in objColl)
                        {
                            Console.WriteLine("ServiceTag=" + o["SerialNumber"].ToString());
                            sw.Write(",  ServiceTag=" + o["SerialNumber"].ToString());
                        }
                        query = new ObjectQuery("Select * from Win32_ComputerSystem");
                        searcher = new ManagementObjectSearcher(scope, query);
                        objColl = searcher.Get();
                        foreach (ManagementObject oReturn in objColl)
                        {
                            string Manufacturer = (string)oReturn["Manufacturer"];
                            sw.Write(", Manufacturer=" + (string)oReturn["Manufacturer"]);
                            string Model = (string)oReturn["Model"];
                            sw.Write(", Model=" + (string)oReturn["Model"]);
                            string name = (string)oReturn["Name"];
                            sw.Write(", name=" + (string)oReturn["name"]);
                            string userName = (string)oReturn["UserName"];
                            sw.Write(", userName=" + (string)oReturn["userName"]);
                            Console.WriteLine((string)oReturn["Manufacturer"]);
                            Console.WriteLine((string)oReturn["Model"]);
                            Console.WriteLine((string)oReturn["Name"]);
                            Console.WriteLine((string)oReturn["UserName"]);
                        }
                        sw.WriteLine();
                        sw.Close();
                    }
                }
                // else 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :" + ex.Message );
                Console.WriteLine("Prova att köra programmet en gång till..");
            }
            Console.WriteLine("");
            Console.Write("<Enter> to quit :");
            Console.ReadLine();
        }
    }
}
