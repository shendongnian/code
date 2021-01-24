    using System;
    namespace ConsoleApp1.Test
    {
        class Program
        {
            static void Maintest(string[] args)
            {
                ILicenseService licenseService = new LicenseService();
                Sport sport = new Sport(licenseService);
                City city = new City(licenseService);
                //car.Name();
                //sport.Name();
                //city.Name();
                //Console.ReadLine();            
                city.OnBuy();
                Console.ReadLine();
            }
        }
        internal abstract class Car
        {
            protected readonly ILicenseService licenseService;
            public Car(ILicenseService _licenseService)
            {
                licenseService = _licenseService;
            }
            internal virtual void Name()
            {
                Console.WriteLine("Car");
            }
            internal event EventHandler Buy;
            internal virtual void OnBuy()
            {
                // TODO
            }
        }
        internal class Sport : Car
        {
            public Sport(ILicenseService _licenseService) : base(_licenseService)
            {
            }
            internal override void Name()
            {
                Console.WriteLine("Sport");
            }
            internal override void OnBuy()
            {
                licenseService.GenerateLicense(new object());
            }
        }
        internal class City : Car
        {
            public City(ILicenseService _licenseService) : base(_licenseService)
            {
            }
            internal override void Name()
            {
                Console.WriteLine("City");
            }
            internal override void OnBuy()
            {
                licenseService.GenerateLicense(new object());
            }
        }
        internal interface ILicenseService
        {
            void GenerateLicense(object param);
        }
        internal class LicenseService : ILicenseService
        {
            public void GenerateLicense(object param)
            {
                // do your stuff
            }
        }
    }
