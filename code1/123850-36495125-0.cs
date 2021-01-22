    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using System.Security.Principal;
    
    namespace HashTest{
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
    
                var ph = new PasswordHasher<WindowsIdentity>();
    
                Console.WriteLine(ph.HashPassword(wi,"test"));
    
                Console.WriteLine(ph.VerifyHashedPassword(wi,"AQAAAAEAACcQAAAAEA5S5X7dmbx/NzTk6ixCX+bi8zbKqBUjBhID3Dg1teh+TRZMkAy3CZC5yIfbLqwk2A==","test"));
    
            }
        }
    
    
    }
 
