    private void CreateInstanceForProviderA()
    {
        a = FactorySingleton.Instance.CreateInstanceA("A");
    
        if (IsNullObject(a))
        {
           return;
        }
    
        a.Owner = Handle.ToInt32();
        lbl_Text.Text = a.Version();
    }
    
    private void CreateInstanceForProviderB()
    {
        b = FactorySingleton.Instance.CreateInstanceB("B");
        if (IsNullObject(b))
        {
           return;
        }
        b.Owner = Handle.ToInt32();
        lbl_Text.Text = b.Version();
    }
    private bool IsNullObject(object obj)
    {
        if (obj == null)
        {
            ShowProviderNotInstanciatedMessage();
            return true;
        }
        return false;
    }
