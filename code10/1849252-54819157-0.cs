    public static string ConvertFlatJson(string input)
    {
        var token = JToken.Parse(input);
        if (token is JObject obj)
        {
            return ConvertJObject(obj).ToString();
        }
        if (token is JArray array)
        {
            return ConvertArray(array).ToString();
        }
        return input;
    }
    private static JObject ConvertJObject(JObject input)
    {
        var enumerable = ((IEnumerable<KeyValuePair<string, JToken>>)input).OrderBy(kvp => kvp.Key);
        var result = new JObject();
        foreach (var outerField in enumerable)
        {
            var key = outerField.Key;
            var value = outerField.Value;
            if (value is JArray array)
            {
                value = ConvertArray(array);
            }
            var fieldNames = key.Split('.');
            var currentObj = result;
            for (var fieldNameIndex = 0; fieldNameIndex < fieldNames.Length; fieldNameIndex++)
            {
                var fieldName = fieldNames[fieldNameIndex];
                if (fieldNameIndex == fieldNames.Length - 1)
                {
                    currentObj[fieldName] = value;
                    continue;
                }
                if (currentObj.ContainsKey(fieldName))
                {
                    currentObj = (JObject)currentObj[fieldName];
                    continue;
                }
                var newObj = new JObject();
                currentObj[fieldName] = newObj;
                currentObj = newObj;
            }
        }
        return result;
    }
    private static JArray ConvertArray(JArray array)
    {
        var resultArray = new JArray();
        foreach (var arrayItem in array)
        {
            if (!(arrayItem is JObject))
            {
                resultArray.Add(arrayItem);
                continue;
            }
            var itemObj = (JObject)arrayItem;
            resultArray.Add(ConvertJObject(itemObj));
        }
        return resultArray;
    }
