    using System;
    using System.Reflection;
    class Program {
        static void Main(string[] args) {
            var ad = AppDomain.CreateDomain("test");
            ad.DomainUnload += ad_DomainUnload;
            //AppDomain.Unload(ad);
            Console.ReadLine();
        }
        static void ad_DomainUnload(object sender, EventArgs e) {
            Console.WriteLine("unloaded, press Enter");
            Console.ReadLine();
        }
    }
