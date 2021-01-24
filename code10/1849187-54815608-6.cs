    static void Main(string[] args)
    {
        var json = "{ \"MyStringValue\":\"String Value\", \"MyClassValue\": \"Test\" }";
        var decodedJson = JsonConvert.DeserializeObject<MainClass>(json);
        Console.WriteLine($"decodedJson.MyStringValue: {decodedJson.MyStringValue}");
        Console.WriteLine($"decodedJson.MyClassValue.Value: {decodedJson.MyClassValue.Value}");
        Console.ReadLine();
    }
