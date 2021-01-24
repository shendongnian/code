    using Newtonsoft.Json.Serialization;
        public void Foo(string jsonData){
        var objData = (JObject)JsonConvert.DeserializeObject(jsonData); // Deserialize json data
        
        dynamic jObject = new JObject();
    jObject.ID = objData.Value<string>("ID");
    jObject.Address = objData.Value<string>("Address");
    jObject.TABLE2 = objData.Value<JArray>("TABLE2");
        }
