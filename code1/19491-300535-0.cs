    public class App
    {
        public static void Main(string[] Args)
        {
            Management.ManagementObjectSearcher Processes = new Management.ManagementObjectSearcher("SELECT * FROM Win32_Process");
            
            foreach (Management.ManagementObject Process in Processes.Get) {
                if (Process.Item("ExecutablePath") != null) {
                    string ExecutablePath = Process.Item("ExecutablePath").ToString;
                    
                    string[] OwnerInfo = new string[2];
                    Process.InvokeMethod("GetOwner", (object[]) OwnerInfo);
                    
                    Console.WriteLine(string.Format("{0}: {1}", IO.Path.GetFileName(ExecutablePath), OwnerInfo(0)));
                }
            }
            
            Console.ReadLine();
        }
    }
