    private string RunTableInfoCommand( TableInfoEnum infoEnum)
    {
        if (this.internalTableNumber == null) {
            return this.RunTableInfoCommand( internalTableName, infoEnum);
        }
        
        return this.RunTableInfoCommand( internalTableNumber.Value, infoEnum);
    }
