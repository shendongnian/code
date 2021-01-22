    public override void Install(System.Collections.IDictionary stateSaver)
    {
         var lParam1 =   GetParam("Param1");
    }
    private string GetParam(string pKey)
    {
            try
            {
                if (this.Context != null)
                {
                    if (this.Context.Parameters != null)
                    {
                        string lParamValue = this.Context.Parameters[pKey];
                        if (lParamValue != null)
                            return lParamValue;
                    }
                }
            }
            catch (Exception)
            {
            }
            return string.Empty;
        }
