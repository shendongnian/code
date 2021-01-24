    public object DeserializeFromTypedString(string input, JsonSerializerSettings settings)
    {
        var r = new Regex(@"^\{\s*""\$type"":\s*""([^""]+)""");
         
        var m = r.Match(input);
        if (m.Success)
        {
            var t = Type.GetType(m.Groups[1].Value);
            return Newtonsoft.Json.JsonConvert.DeserializeObject(input, t, settings);
        }
        else
        {
            throw new Exception("$type not found!");
        }
    }
