    public async Task<IEnumerable<TResult>> ParseStream<TResult>(string stringSerialized)
    {
      using (StringReader streamReader = new StringReader(stringSerialized))
      using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
      {
                JObject parsedData = await JObject.LoadAsync(jsonTextReader);
                if (parsedData == null || parsedData[dataProperty] == null || parsedData[dataProperty].Children().Any() == false)
                    return new List<T>();
                else
                    return parsedData["d"].Children().Select(s => s.ToObject<TResult>());
       }
     }
