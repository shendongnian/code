    using System;
    using System.Management;
    
    public class Foo 
    {
        public static void Main() 
        {
           var instances = new ManagementClass("Win32_SerialPort").GetInstances();
           foreach ( ManagementObject port in instances )
           {
               Console.WriteLine("{0}: {1}", port["deviceid"], port["name"]);
           }
    }
