    Type mType = Type.GetType("UIEventListener");
    
    if(mType  != null)
    {
         UIEventListener.Get(this.gameObject).onClick += expiryDateSettingsUIController.ActiveDeactiveUICaller;
    }
