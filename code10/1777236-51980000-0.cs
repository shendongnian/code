    public static async void PostUploadtoCloud(List<Dictionary<string, byte[]>> _commonFileCollection)
    {
        Dictionary<string, Byte[]> _dickeyValuePairs = new Dictionary<string, byte[]>();
        Byte[] itemData;
        foreach (var item in _commonFileCollection)
        {    
            foreach (var kvp in item)
            {
                if (!_dickeyValuePairs.TryGetValue(kvp.Key, out itemData))
                {
                    _dickeyValuePairs.Add(kvp.Key, kvp.Value);
                }
            }
    
        }
    }
