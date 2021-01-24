    protected List<BetweenTagData> BetweenTagDataPull(string ctrlName)
    {
        List<BetweenTagData> data = new List<BetweenTagData>();
    
        if (ctrlName == "Label")
        {
            data.Add(new BetweenTagData() {text = TagLabelTxtbxEnterText.Text});
        }
    
        return data;
    }
    static public string TagBetween(IEnumerable<BetweenTagData> betweenData)
    {
        var data = betweenData.Where(bd => !string.IsNullOrEmpty(bd.text)).Select(bd => bd.text);
        StringBuilder betweenString = new StringBuilder();
        foreach (string row in data)
        {
            betweenString.Append(row);
        }   
        return betweenString.ToString();
    }
