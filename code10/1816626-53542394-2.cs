    static void Main()
    {
        string trackingNumber = "1Z204E380338943508";
        string carrierName = null;
        if (trackingNumber.Contains("1Z"))
        {
            carrierName = "UPS";
        }
        else if (trackingNumber.Length >= 12 && trackingNumber.Length < 14)
        {
            carrierName = "FedEx";
        }
        else if (trackingNumber.Length >= 20 && trackingNumber.Length < 22)
        {
            carrierName = "USPS";
        }
        if (carrierName == null)
        {
            Console.WriteLine("Did not work.");
        }
        else
        {
            Console.WriteLine($"Carrier name: {carrierName}");
        }
        GetKeyFromUser("\nPress any key to exit...");
    }
