    string path = @"c:\XMLFile1.xml";
    XmlSerializer ser = new XmlSerializer(typeof(response);
    ResponseGeographyVendorRegionVehicle i;
    using (Stream reader = new FileStream(path,FileMode.Open)) 
    {
        i = ((Response)ser.Deserialize(reader)).Geography.vendorfield;
        Console.WriteLine(i.Price);
        Console.ReadLine();
    }
