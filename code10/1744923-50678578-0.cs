     string jsonstring = "{\"cars\": {\"bmw\": \"true\", \"benz\": \"false\",  \"kia\": \"true\",  \"hyundai\": \"false\", \"madza\": \"false\",  \"ford\": \"false\"}}";
     dynamic data = JObject.Parse(jsonstring); 
     CarsViewModel obj = new CarsViewModel(); 
     var mydetails2 = JsonConvert.SerializeObject(data.cars);
     var mydetails3 = JsonConvert.DeserializeObject<Dictionary<string, bool>>(mydetails2);
      foreach (var pair in mydetails3)
        {
           // Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            if (pair.Value == true)
            {
                if (pair.Key == "bmw")
                {
                    obj.bmw = pair.Value;
                }
                else if (pair.Key == "benz")
                {
                    obj.benz = pair.Value;
                }
                else if (pair.Key == "kia")
                {
                    obj.kia = pair.Value;
                }
                else if (pair.Key == "hyundai")
                {
                    obj.hyundai = pair.Value;
                }
                else if (pair.Key == "madza")
                {
                    obj.madza = pair.Value;
                }
                else if (pair.Key == "ford")
                {
                    obj.ford = pair.Value;
                }
            }
        }
