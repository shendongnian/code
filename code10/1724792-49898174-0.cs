    public class Flight
    {
        public string  flightNumber { get; set; }
        public Dictionary<string, string> seatjson { get; set; }
    }
    
    public List<Flight> GetJsonFileContentInList(string jsonFilePath)
    {
        Stream jsonStream = MemoryStream(File.ReadAllBytetes(jsonFilePath));
        StreamReader reader = new StreamReader(jsonStream);
        string json = reader.ReadToEnd();
    
        return new JavaScriptSerializer().Deserialize<List<Flight>>(json);
    }
