    foreach (var item in dict)
    {
            inputText = inputText.Replace(item.Key, item.Value)
                                 .Replace(item.Key.ToLower(), item.Value.ToLower());
    }
