            ItemLookup itemLookup = new ItemLookup()
            {
                AssociateTag = "XXXXX-20",
            };
            itemLookup.AWSAccessKeyId = ACCESS_ID;
            ItemLookupRequest itemLookupRequest = new ItemLookupRequest();
            itemLookupRequest.IdTypeSpecified = true;
            itemLookupRequest.IdType = searchType;
            itemLookupRequest.SearchIndex = "All";
            itemLookupRequest.ItemId = upcEanList;
            itemLookupRequest.ResponseGroup = new[] { "OfferSummary", "ItemAttributes" };
            itemLookup.Request = new ItemLookupRequest[] { itemLookupRequest };
