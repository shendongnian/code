    public static string Replace(this string str, string oldValue, string newValue,
                StringComparison comparison = StringComparison.Ordinal)
    {
        var index = str.IndexOf(oldValue, comparison);
        while (index >= 0)
        {
            str = str.Remove(index, oldValue.Length);
            str = str.Insert(index, newValue);
            index = str.IndexOf(oldValue, comparison);
        }
    
        return str;
    }
    
    var fruitDictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) { { "Apple" , "Fruit" }, { "Orange", "Fruit" }, { "Spinach", "Greens" } };
    
    TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
    string data = textRange.Text;
    
    foreach (var kvp in fruitDictionary)
        data = data.Replace(kvp.Key, kvp.Value, StringComparison.InvariantCultureIgnoreCase)
    
    richTextBox2.AppendText(data);
