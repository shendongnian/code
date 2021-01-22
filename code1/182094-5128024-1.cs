    public static byte[] ReadBinaryFile(string fileName)
    {
        const int adTypeBinary = 1;
        using (dynamic adoCom = AutomationFactory.CreateObject("ADODB.Stream"))
        {
            adoCom.Type = adTypeBinary;
            adoCom.Open();
            adoCom.LoadFromFile(fileName);
            return adoCom.Read();
        }
    }
