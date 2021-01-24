     var jToken = JObject.Parse(responseContent);
            var bodyString = jToken.SelectToken("body");
            var bodyJson = JsonConvert.SerializeObject(bodyString);
            List<RulesEngineOutput> result = new List<RulesEngineOutput>();
            
            try
            {
                foreach (var item in bodyString)
                {
                    var formattedItem = item.SelectToken("Result");
                    var  resultItem = JsonConvert.DeserializeObject<RulesEngineOutput>(formattedItem.ToString());
                       result.Add(resultItem);
                }
                
            }
