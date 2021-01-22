    public int Number
            {
                get
                {
                    string returnValue;
                    internalTableClass myinstance(parameters);
                    return Convert.ToInt32(this.RunTableInfoCommand(myinstance, TableInfoEnum.TAB_INFO_NUM));
                }
            }
