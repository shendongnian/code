    private void CreateInstanceForProviderB(Provider provider)
    {
        // Change object to what the provider type is.
        object provider = null;
    
        switch (provider)
        {
                case Provider.A:
                    provider = FactorySingleton.Instance.CreateInstanceA("A");
                    break;
                case Provider.B:
                    provider = FactorySingleton.Instance.CreateInstanceB("B");
                    break;
        }
    
        if (provider == null)
        {
            ShowProviderNotInstanciatedMessage();
            return;
        }
    
        provider.Owner = Handle.ToInt32();
        lbl_Text.Text = provider.Version();
    }
