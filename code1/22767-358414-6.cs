     private int? internalTableNumber;
     private int InternalTableNumber
     {
         get
         {
             if (!internalTableNumber.HasValue)
             {
                 internalTableNumber = GetValueFromTableName( internalTableName );
             }
             return internalTableNumber;
         }
         set
         {
             internalTableNumber = value;
         }
     }
     public int Number
     {
         get
         {
            string value = this.RunTableInfoCommand(InternalTableNumber,
                                                    TableInfoEnum.TAB_INFO_NUM);
            return Convert.ToInt32( value );
         }
     }
