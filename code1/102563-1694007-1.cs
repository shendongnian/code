    Microsoft.Office.Interop.Outlook.NameSpace ns = this.Application.Session;
    foreach (Microsoft.Office.Interop.Outlook.Store store in ns.Stores)
    {
        if (store.ExchangeStoreType == Microsoft.Office.Interop.Outlook.OlExchangeStoreType.olPrimaryExchangeMailbox)
        {
            ns.Stores[1].PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x661D000B", true);
            break;
        }
    }
