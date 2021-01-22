    public override void ItemAdded(SPItemEventProperties pobjSPItemEventProperties)
    {         
        using (SPWeb objSPWeb = pobjSPItemEventProperties.OpenWeb())
        {
            string strFileUrl = pobjSPItemEventProperties.ListItem.File.Url;
            //save to DB here
        }
    }  
