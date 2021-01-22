    using System;
    using System.Text;
    using System.Management;
    
    namespace ConsoleApplication1
    {
      class Program
      {
        public static bool AntivirusInstalled()
        {
    
          string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter";
          try
          {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
            ManagementObjectCollection instances = searcher.Get();
            return instances.Count > 0;
          }
    
          catch (Exception e)
          {
            Console.WriteLine(e.Message);
          }
    
          return false;
        } 
    
        public static void Main(string[] args)
        {
          bool returnCode = AntivirusInstalled();
          Console.WriteLine("Antivirus Installed " + returnCode.ToString());
          Console.WriteLine();
          Console.Read();
        }
    
    
      }
    }
