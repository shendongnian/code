    public int Number
            {
                get
                {
                    string returnValue;
                    internalTableClass myinstance(parameters);
                    return Convert.ToInt32(this.RunTableInfoCommand(myinstance.giveInternalTableIdentifier, TableInfoEnum.TAB_INFO_NUM));
                }
            }
