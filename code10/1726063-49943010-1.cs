    class WhateverYourClassIsCalled
    {
        private IEnumerable<ItemModel> items;
    
        private void Skills_Button_Click(object sender, RoutedEventArgs e)
        {
            items = GetItems();
        }
    
        private IEnumerable<ItemModel> GetItems()
        {
            Dictionary<string, Item> dictionary = JsonConvert
                .DeserializeObject<Dictionary<string, Item>>(database);
    
            foreach (KeyValuePair<string, Item> item in dictionary)
            {
                yield return new ItemModel(
                    itemName: item.Key,
                    sellPrice: item.Value.sell_average,
                    buyPrice: item.Value.buy_average);
            }
        }
    
        // You called this method, "S", which is a poor name!
        private decimal GetSellPrice(string itemName)
        {
            return items
    	        .SingleOrDefault(item => item.ItemName == itemName)
                .SellPrice;
        }
    }
