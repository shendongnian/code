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
        return string.Join("", betweenData.Where(bd => !string.IsNullOrEmpty(bd.text)).Select(bd => bd.text));
    }
