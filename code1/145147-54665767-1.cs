    public string FieldIdList
    {
        get { return fieldIdList.ToString(); }
        set { fieldIdList = ChangeFieldList(value); }
    }
    
    private string ChangeFieldIdList(int i) {
        return i.ToString();
    }
