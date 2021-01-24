    var files = JArray.Parse(JSON);
    var recList = files.SelectToken("$..lines");
    var str = JsonConvert.SerializeObject(recList);
    var regex = new System.Text.RegularExpressions.Regex(@"(\{[^}]+)\},\{([^}]+)\},\{([^}]+)\}");
    var output = regex.Replace(str, "$1, $2, $3 }");
    System.Data.DataTable dt = (System.Data.DataTable)JsonConvert.DeserializeObject(str, (typeof(System.Data.DataTable)));
