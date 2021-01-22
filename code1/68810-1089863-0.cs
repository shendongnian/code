    private bool _useOldMethodName = false;
    public void MethodAlias(string arg1)
    {
        if (_useOldMethodName)
        {
            Reference.OldFunctionName(arg1);
        }
        else
        {
            try
            {
                Reference.NewFunctionName(arg1);
            }
            catch (MethodNotFoundException mnfe)
            {
                _useOldMethodName = true;
            }
        }
    }
