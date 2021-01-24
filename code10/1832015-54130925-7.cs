    public void JsonFileReader()
    {
        using (StreamReader r = new StreamReader("yourJsonFile.json"))
        {
            string json = r.ReadToEnd();
            List<Name> items = JsonConvert.DeserializeObject<Name>(json);
        }
    }
