    private ObservableCollection<ItemGrid> _itemGrid = new ObservableCollection<ItemGrid>();
        public ObservableCollection<ItemGrid> ItemGrid
        {
            get
            {
                return _itemGrid;
            }
            set
            {
                _itemGrid = value;
            }
        }
        private void ItemField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isBeginingEdit) return;
            //here we show the item selector and take care of autocomplete
            var textBox = sender as TextBox;
            if (textBox.Text != "")
            {
                var _itemSourceList = new CollectionViewSource() { Source = ItemGrid };
                ICollectionView Itemlist = _itemSourceList.View;
                ItemSearchText = textBox.Text;
                Itemlist.Filter = ItemFilter;
                var count = _itemSourceList.View.Cast<ItemGrid>().Count();
                if (count > 0)
                {
                    ItemsGrid.ItemsSource = Itemlist;
                } 
            } 
       }
