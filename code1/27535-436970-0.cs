    if (!(string.IsNullOrEmpty(ISBN) && string.IsNullOrEmpty(ASIN)))
    {
        AWSECommerceService service = new AWSECommerceService();
        ItemLookup lookup = new ItemLookup();
        ItemLookupRequest request = new ItemLookupRequest();
    
        lookup.AssociateTag = ConfigurationManager.AppSettings["AssociatesTag"];
        lookup.AWSAccessKeyId = ConfigurationManager.AppSettings["AWSAccessKey"];
        if (string.IsNullOrEmpty(ASIN))
        {
            request.IdType = ItemLookupRequestIdType.ISBN;
            request.ItemId = new string[] { ISBN.Replace("-", "") };
        }
        else
        {
            request.IdType = ItemLookupRequestIdType.ASIN;
            request.ItemId = new string[] { ASIN };
        }
        request.ResponseGroup = ConfigurationManager.AppSettings["AWSResponseGroups"].Split(new char[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
    
        lookup.Request = new ItemLookupRequest[] { request };
        ItemLookupResponse response = service.ItemLookup(lookup);
    
        if (response.Items.Length > 0 && response.Items[0].Item.Length > 0)
        {
            Item item = response.Items[0].Item[0];
            if (item.MediumImage == null)
            {
                bookImageHyperlink.Visible = false;
            }
            else
            {
                bookImageHyperlink.ImageUrl = item.MediumImage.URL;
            }
            bookImageHyperlink.NavigateUrl = item.DetailPageURL;
            bookTitleHyperlink.Text = item.ItemAttributes.Title;
            bookTitleHyperlink.NavigateUrl = item.DetailPageURL;
            if (item.OfferSummary.LowestNewPrice == null)
            {
                if (item.OfferSummary.LowestUsedPrice == null)
                {
                    priceHyperlink.Visible = false;
                }
                else
                {
                    priceHyperlink.Text = string.Format("Buy used {0}", item.OfferSummary.LowestUsedPrice.FormattedPrice);
                    priceHyperlink.NavigateUrl = item.DetailPageURL;
                }
            }
            else
            {
                priceHyperlink.Text = string.Format("Buy new {0}", item.OfferSummary.LowestNewPrice.FormattedPrice);
                priceHyperlink.NavigateUrl = item.DetailPageURL;
            }
            if (item.ItemAttributes.Author != null)
            {
                authorLabel.Text = string.Format("By {0}", string.Join(", ", item.ItemAttributes.Author));
            }
            else
            {
                authorLabel.Text = string.Format("By {0}", string.Join(", ", item.ItemAttributes.Creator.Select(c => c.Value).ToArray()));
            }
            ItemLink link = item.ItemLinks.Where(i => i.Description.Contains("Wishlist")).FirstOrDefault();
            if (link == null)
            {
                wishListHyperlink.Visible = false;
            }
            else
            {
                wishListHyperlink.NavigateUrl = link.URL;
            }
        }
    }
