    using (StreamReader reader = new StreamReader("appsettings.json"))
       {
            dynamic settingsJson = reader.ReadToEnd();
            var settings = JObject.Parse(settingsJson);
            var testOneConfigObj = JsonConvert.DeserializeObject<TestOneConfig>(settings.TestOneConfig.ToString());                    
        }
