    JObject obj;
    using (var reader = new JsonTextReader(new StringReader(json))) {
        // DateParseHandling.None is what you need
        reader.DateParseHandling = DateParseHandling.None;
        obj = JObject.Load(reader);
    }
