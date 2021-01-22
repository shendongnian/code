    public string FieldIdList
    {
        get { return fieldIdList.ToString(); }
        set { fieldIdList = ChangeFieldList(23); }
    }
    
    private string ChangeFieldIdList(int i) {
        return i.ToString();
    }
