    internal class LicenseService
    {
        internal void GenerateLicense(Car sender)
        {
            Random rnd = new Random();
            string carName = sender.CarName;
            string licenseNumber = "";
            for(int i = 0; i < 5; i++)
            {
                licenseNumber += rnd.Next(0, 9).ToString();
            }
            Console.WriteLine("{1} Car has been bought, this is the license number: {0}", licenseNumber, carName);
        } 
    }
