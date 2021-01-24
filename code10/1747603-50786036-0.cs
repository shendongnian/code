    JArray files = JArray.Parse(test1);
        foreach (JObject content in test1.Children<JObject>())
        {
            foreach (JProperty prop in content.Properties())
            {
                string tempValue = prop.Value.ToString(); 
            }
        }
