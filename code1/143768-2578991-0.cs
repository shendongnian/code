    public IDictionary<string, object> GetClipboardData()
    {
        var dict = new Dictionary<string, object>();
        var dataObject = Clipboard.GetDataObject();
        foreach(var format in dataObject.GetFormats())
        {
            dict.Add(format, dataObject.GetData(format));
        }
        return dict;
    }
    
    public void SetClipboardData(IDictionary<string, object> dict)
    {
        var dataObject = Clipboard.GetDataObject();
        foreach(var kvp in dict)
        {
            dataObject.SetData(kvp.Key, kvp.Value);
        }
    }
    ...
    var backup = GetClipboardData();
    // Do something with the clipboard...
    ...
    SetClipboardData(backup);
