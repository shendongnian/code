    using System.IO;
    using System.Text;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public static void SplitJson(Uri objUri, string arrayPropertyName)
    {
        string templateFileName = @"C:\Temp\template.json";
        string arrayFileName = @"C:\Temp\array.json";
        // Split the original JSON stream into two temporary files:
        // one that has the huge array and one that has everything else
        HttpClient client = new HttpClient();
        using (Stream stream = client.GetStreamAsync(objUri).Result)
        using (JsonReader reader = new JsonTextReader(new StreamReader(inputStream)))
        using (JsonWriter templateWriter = new JsonTextWriter(new StreamWriter(templateFileName)))
        using (JsonWriter arrayWriter = new JsonTextWriter(new StreamWriter(arrayFileName)))
        {
            if (reader.Read() && reader.TokenType == JsonToken.StartObject)
            {
                templateWriter.WriteStartObject();
                while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                {
                    string propertyName = (string)reader.Value;
                    reader.Read();
                    templateWriter.WritePropertyName(propertyName);
                    if (propertyName == arrayPropertyName)
                    {
                        arrayWriter.WriteToken(reader);
                        templateWriter.WriteStartObject();  // empty placeholder object
                        templateWriter.WriteEndObject();
                    }
                    else if (reader.TokenType == JsonToken.StartObject ||
                             reader.TokenType == JsonToken.StartArray)
                    {
                        templateWriter.WriteToken(reader);
                    }
                    else
                    {
                        templateWriter.WriteValue(reader.Value);
                    }
                }
                templateWriter.WriteEndObject();
            }
        }
        // Now read the huge array file and combine each item in the array
        // with the template to make new files
        JObject template = JObject.Parse(File.ReadAllText(templateFileName));
        using (JsonReader arrayReader = new JsonTextReader(new StreamReader(arrayFileName)))
        {
            int counter = 0;
            while (arrayReader.Read())
            {
                if (arrayReader.TokenType == JsonToken.StartObject)
                {
                    counter++;
                    JObject item = JObject.Load(arrayReader);
                    template[arrayPropertyName] = item;
                    string fileName = string.Format(@"C:\Temp\output_{0}_{1}_{2}.json",
                                                    template["name"], template["age"], counter);
                    File.WriteAllText(fileName, template.ToString());
                }
            }
        }
        // Clean up temporary files
        File.Delete(templateFileName);
        File.Delete(arrayFileName);
    }
