    using System;
    using Microsoft.Win32;
    
    namespace RegistryTestApp
    {
       class Program
       {
          static void Main(string[] args)
          {
             object mailClient = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Clients\Mail", "", "none"); 
             Console.WriteLine(mailClient.ToString());
          }
       }
    }
