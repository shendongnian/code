            var stringUnit = "{\"UnitYear\":\"2018\",\"UnitModel\":\"F250 Super Duty\"}";
            var assetUnit = "{\"AssetYear\":\"2019\",\"AssetModel\":\"Corvette Stingray\"}";
            var unit = Newtonsoft.Json.JsonConvert.DeserializeObject<Asset>(stringUnit);
            if (unit.IsValid())
            {
                Console.WriteLine(unit.AssetModel);
            }
            else
            {
                Console.WriteLine("Json can't convert this");
            }
