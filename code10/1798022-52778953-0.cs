    private static void Main(string[] args)
        {
            AutoMapperConfiguration.Configure();
            string json = File.ReadAllText("jsonData.json");
            JArray assets = JArray.Parse(json);
            List<AssetDTO> assetDTOList = new List<AssetDTO>();
            for (int i = 0; i < assets.Count; i++)
            {
                JObject jObject = JObject.Parse(assets[i].ToString());
                AssetDTO assetDTO = Mapper.Map<AssetDTO>(jObject);
                assetDTOList.Add(assetDTO);
            }
            
        }
