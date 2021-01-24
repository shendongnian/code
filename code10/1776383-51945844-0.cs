    using System.Management; 
    
     namespace KMM_HighPerformance.Models
     {
        class GetHardwareInfo
        {
    
            static public void GetCPU()
            {
                var mbs = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
                var mbsList = mbs.Get();
    
                foreach (ManagementObject mo in mbsList)
                {
                   var cpuid = mo["ProcessorID"].ToString();
           
                }
            }
    
        }
    }
