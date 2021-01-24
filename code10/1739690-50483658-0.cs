    public IDictionary<string, object> DeserializeToDictionary(string input)
    {
          dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(input);
          return (IDictionary<string, object>)obj;
    }
