    var noFormatting = new JsonSerializerSettings();
    noFormatting.Formatting = Formatting.None;
    var test = new {
        Name = "Test\r\nName",
        Value = "Test2"
    };
    Console.WriteLine(JsonConvert.SerializeObject(test, noFormatting));
