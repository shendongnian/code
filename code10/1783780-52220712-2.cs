       public async Task<IEnumerable<TResult>> ParseStream<TResult>(Stream contentStream)
        {
            using (StreamReader streamReader = new StreamReader(contentStream))
            using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
            {
                jsonTextReader.DateFormatString = _dateFormatString;
                JObject parsedData = await JObject.LoadAsync(jsonTextReader);
                if (parsedData == null || parsedData["d"] == null || parsedData["d"].Children().Any() == false)
                    return new List<TResult>();
                else
                    return parsedData["d"].Children().Select(s => s.ToObject<TResult>());
            }
        }
