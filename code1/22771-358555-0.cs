    public int Number
    {
        get
        {
            return iTable.RunTableInfoCommand(TableInfoEnum.TAB_INFO_NUM);
        }
    }
