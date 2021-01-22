    using System;
    using System.Management;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_UserAccount Where LocalAccount = True");
                ManagementObjectCollection results = mos.Get();
    
                foreach (ManagementObject user in results)
                {
                    Console.WriteLine("Account Type: " + user["AccountType"].ToString());
                    Console.WriteLine("Caption: " + user["Caption"].ToString());
                    Console.WriteLine("Description: " + user["Description"].ToString());
                    Console.WriteLine("Disabled: " + user["Disabled"].ToString());
                    Console.WriteLine("Domain: " + user["Domain"].ToString());
                    Console.WriteLine("Full Name: " + user["FullName"].ToString());
                    Console.WriteLine("Local Account: " + user["LocalAccount"].ToString());
                    Console.WriteLine("Lockout: " + user["Lockout"].ToString());
                    Console.WriteLine("Name: " + user["Name"].ToString());
                    Console.WriteLine("Password Changeable: " + user["PasswordChangeable"].ToString());
                    Console.WriteLine("Password Expires: " + user["PasswordExpires"].ToString());
                    Console.WriteLine("Password Required: " + user["PasswordRequired"].ToString());
                    Console.WriteLine("SID: " + user["SID"].ToString());
                    Console.WriteLine("SID Type: " + user["SIDType"].ToString());
                    Console.WriteLine("Status: " + user["Status"].ToString());
                }
                Console.ReadKey();
            }
        }
    }
