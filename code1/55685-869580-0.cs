    // exchange 2007 lets us use web services to check mailboxes.
    using (ExchangeServiceBinding exchangeServer = new ExchangeServiceBinding())
    {
        ICredentials creds = new NetworkCredential("user","password");
        exchangeServer.Credentials = creds;
        exchangeServer.Url = "https://myexchangeserver.com/EWS/Exchange.asmx";
        FindItemType findItemRequest = new FindItemType();
        findItemRequest.Traversal = ItemQueryTraversalType.Shallow;
    
        // define which item properties are returned in the response
        ItemResponseShapeType itemProperties = new ItemResponseShapeType();
        itemProperties.BaseShape = DefaultShapeNamesType.AllProperties;
        findItemRequest.ItemShape = itemProperties;
    
        // identify which folder to search
        DistinguishedFolderIdType[] folderIDArray = new DistinguishedFolderIdType[1];
        folderIDArray[0] = new DistinguishedFolderIdType();
        folderIDArray[0].Id = DistinguishedFolderIdNameType.inbox;
    
        // add folders to request
        findItemRequest.ParentFolderIds = folderIDArray;
    
        // find the messages
        FindItemResponseType findItemResponse = exchangeServer.FindItem(findItemRequest);
    
        // read returned
        FindItemResponseMessageType folder = (FindItemResponseMessageType)findItemResponse.ResponseMessages.Items[0];
        ArrayOfRealItemsType folderContents = new ArrayOfRealItemsType();
        folderContents = (ArrayOfRealItemsType)folder.RootFolder.Item;
        ItemType[] items = folderContents.Items;
    
        // if no messages were found, then return null -- we're done
        if (items == null || items.Count() <= 0)
            return null;
    
        // FindItem never gets "all" the properties, so now that we've found them all, we need to get them all.
        BaseItemIdType[] itemIds = new BaseItemIdType[items.Count()];
        for (int i = 0; i < items.Count(); i++)
            itemIds[i] = items[i].ItemId;
    
        GetItemType getItemType = new GetItemType();
        getItemType.ItemIds = itemIds;
        getItemType.ItemShape = new ItemResponseShapeType();
        getItemType.ItemShape.BaseShape = DefaultShapeNamesType.AllProperties;
        getItemType.ItemShape.BodyType = BodyTypeResponseType.Text;
        getItemType.ItemShape.BodyTypeSpecified = true;
    
        GetItemResponseType getItemResponse = exchangeServer.GetItem(getItemType);
        ItemType[] messages = new ItemType[getItemResponse.ResponseMessages.Items.Count()];
    
        for (int j = 0; j < messages.Count(); j++)
            messages[j] = ((ItemInfoResponseMessageType)getItemResponse.ResponseMessages.Items[j]).Items.Items[0];
    
        return messages;
    }
