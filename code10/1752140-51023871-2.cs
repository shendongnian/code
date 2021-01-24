    var template = "<h1>Hello @Model.name!</h1>";
    var json = @"{ }";
    var converter = new Newtonsoft.Json.Converters.ExpandoObjectConverter();
    var model = JsonConvert.DeserializeObject<System.Dynamic.ExpandoObject>(json, converter);
    var result = Engine.Razor.RunCompile(template, "templateKey", null, model);
