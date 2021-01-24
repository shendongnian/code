    public async Task<IEnumerable<TResult>> ParseJson<TResult>(string stringSerialized)
    {
      using (StringReader streamReader = new StringReader(stringSerialized))
      using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
      {
                JObject parsedData = await JObject.LoadAsync(jsonTextReader);
                if (parsedData == null || parsedData["d"] == null || parsedData["d"].Children().Any() == false)
                    return new List<T>();
                else
                    return parsedData["d"].Children().Select(s => s.ToObject<TResult>());
       }
     }
