     private async void CheckBanner()
            {
                try
                {
                    string[] productKinds = { "Consumable", "UnmanagedConsumable" };
                    StatusBar.Visibility = Visibility.Visible;
                    var userPurchases = await _storeContext.GetUserCollectionAsync(productKinds);
                    StatusBar.Visibility = Visibility.Collapsed;
                    foreach (var item in userPurchases.Products)
                    {
                        var product = item.Value;
                        TextBlock count = GetProductQuatity(product.ExtendedJsonData)
                    }
                       
                }
                catch
                {
                    //
                }
    
            }
    
            private string GetProductQuatity(string jsonData)
            {
    
                try
                {
                    var obj = JObject.Parse(jsonData);
                    return obj["DisplaySkuAvailabilities"][0]["Sku"]["CollectionData"]["quantity"].ToString();
                }
                catch
                {
                    return "1";
                }
            }
