    var records = ((IEnumerable)enumerable).Cast<object>().ToList();
    var result = new Dictionary<string, IList<string>>();
    // Filter and get all propertInfo from the beginning
    var props = records.Count()>0 ? records.First().GetType().GetProperties().Where(x=> properties.Any(a=> a == x.ProperyName)).ToList() : List<PropertyInfo>();
    foreach (object record in records)
    {
        foreach (var prop in props)
        {
            var colValue = prop.GetValue(record);
            if (colValue != null)
            {
                if (result.ContainsKey(prop.ProperyName))
                {
                    result[prop.ProperyName].Add(colValue.ToString());
                }
                else
                {
                    result.Add(prop.ProperyName, new List<string>() { colValue.ToString() });
                }
            }
        }
    }
