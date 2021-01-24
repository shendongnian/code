    var parsedJson = JObject.Parse(jsonn);
                var length = parsedJson["Results"]["WSOutput"]["value"]["Values"][0].Count();
                IDictionary<string, object> flexibleJson = new ExpandoObject();
    
                for (int i = 0; i < length; i++)
                {
                    string colName = parsedJson["Results"]["WSOutput"]["value"]["ColumnNames"][i].ToString();
                    string colValue = parsedJson["Results"]["WSOutput"]["value"]["Values"][0][i].ToString(); // single result for now
                    flexibleJson.Add(colName, colValue);
                }
    
                var serialized = JsonConvert.SerializeObject(flexibleJson);
