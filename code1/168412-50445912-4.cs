    public static void EasyJson()
    {
        var jsonText = @"{
            ""some_number"": 108.541,
            ""date_time"": ""2011-04-13T15:34:09Z"",
            ""serial_number"": ""SN1234""
        }";
        var jss = new JavaScriptSerializer();
        var dict = jss.Deserialize<dynamic>(jsonText);
        Console.WriteLine(dict["some_number"]);
        Console.ReadLine();
    }
