    public static void WriteBinaryFile(string fileName, byte[] binary)
    {
        const int adTypeBinary = 1;
        const int adSaveCreateOverWrite = 2;
        using (dynamic adoCom = AutomationFactory.CreateObject("ADODB.Stream"))
        {
            adoCom.Type = adTypeBinary;
            adoCom.Open();
            adoCom.Write(binary);
            adoCom.SaveToFile(fileName, adSaveCreateOverWrite);
        }
    }
