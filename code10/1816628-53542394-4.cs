    static void Main()
    {
        string carrierName = GetCarrierName("1Z204E380338943508");
        if (carrierName == null)
        {
            Console.WriteLine("Unknown tracking id format.");
        }
        else
        {
            Console.WriteLine($"Carrier name: {carrierName}");
        }
        GetKeyFromUser("\nPress any key to exit...");
    }
