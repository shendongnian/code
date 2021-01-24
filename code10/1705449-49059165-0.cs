    var dictionary = new Dictionary<string, string>();
    foreach (var resultRow in resultRows)
    {
        if(!string.IsNullorEmpty(resultRow))
        {
            var rowItems = resultRow.Split('|').ToList();
            dictionary.Add(rowItems.First(), string.Join("|", rowItems.Skip(1));
        }
    }
