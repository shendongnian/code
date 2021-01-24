    public static class MutexManager
    {
       private static string mutexName => "MyAppName" + System.Security.Principal.WindowsIdentity.GetCurrent()
                                                                .User?.AccountDomainSid;
       public static bool CreateApplicationMutex()
       {
          new Mutex(false, mutexName, out var createdNew);
    
          return createdNew;
       }
    }
    
    private static void Main(string[] args)
    {
       Console.WriteLine(MutexManager.CreateApplicationMutex());
       Console.ReadKey();
    }
