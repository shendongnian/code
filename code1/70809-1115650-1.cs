        DataToSerialize test = new DataToSerialize();
        test.Name = "TestData" + Environment.NewLine;
        XmlSerializer configSerializer = new XmlSerializer(typeof(DataToSerialize));
        MemoryStream ms = new MemoryStream();
        StreamWriter sw = new StreamWriter(ms);
        configSerializer.Serialize(sw, test);
        ms.Position = 0;
        XmlTextReader reader = new XmlTextReader(ms);
        reader.Normalization = false;
        DataToSerialize deserialized = (DataToSerialize)configSerializer.Deserialize(reader);
        if (deserialized.Name.Equals("TestData" + Environment.NewLine))
        {
            Console.WriteLine("Same");
        }
