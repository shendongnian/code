    string dataToDeserialize = GetYourDataFromDb();
    xser = new XmlSerializer(typeof(PrinterSettings));
    using (StringReader sr = new StringReader(dataToDeserialize))
    {
        
        PrinterSettings prn = (PrinterSettings)xser.Deserialize(sr);
        Console.WriteLine(prn.PrintFileName);
    }
