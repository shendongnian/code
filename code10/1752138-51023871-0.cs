    string template = "<h1>Hello @Model.name!</h1>";
    String json = @"{  }";
    var converter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
    object jsonModel = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject>(json, converter);
    var result = Engine.Razor.RunCompile(template, "templateKey", null, jsonModel);
