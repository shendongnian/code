    [DataObjectMethod(DataObjectMethodType.Select)]
    public IEnumerable<OperatorField> FindByType(String type)
    {
        List<OperatorField> list = new List<OperatorField>();
        foreach (OperatorField ce in OperatorFields)
        {
            if (ce.Type == type)
            {
                list.Add(ce);
            }
        }
        return list;
    }
    
