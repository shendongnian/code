    var jsonResult = JsonConvert.SerializeObject(consolidatedData);
    var newList = new List<string>(new string[] {jsonResult});
    var newResult =  JsonConvert.SerializeObject(newList);
    string path = Server.MapPath("~/JSON_Results/");
    System.IO.File.WriteAllText(path + "data.json", newResult);
