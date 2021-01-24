    public static void SaveScenario(string fileURL, Scenario scenario)
    {
        scenario.ScenarioFile = fileURL;
        using (FileStream writer = new FileStream(fileURL, FileMode.Create))
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(Scenario));
            ser.WriteObject(writer, scenario);
        } 
    }
    public static Scenario ReadScenario(string fileURL)
    {
        FileStream fs = new FileStream(fileURL, FileMode.Open);
        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
        DataContractSerializer ser = new DataContractSerializer(typeof(Scenario));
        Scenario deserializedScenario = (Scenario)ser.ReadObject(reader, true);
        reader.Close();
        fs.Close();
        return deserializedScenario;
    }
