        private void serchForElement(string searchText)
        {            
            searchText = searchText.ToLower();
            List<string> list = (from items in item
                                 where items.ToLower().Contains(searchText.ToLower())
                                 select items).ToList<string>();            
            SimpleList.ItemsSource = list;
        }
