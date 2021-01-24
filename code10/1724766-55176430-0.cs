    private bool? _IsVisible;
        public bool? IsVisible
        {
            get { return _IsVisible; }
            set {
                _IsVisible = value;
                if(_IsVisible !=null)
                {
                    OnPropertyChanged();
    
                }
            }
    
        }
         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                {
        
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
    
        private void UpdateProducts(Product product)
                {
        
                    if(searchProducts != null && searchProducts.Count > 0)
                    {
                        var index = searchProducts.IndexOf(product);
                        searchProducts.Remove(product);
                        searchProducts.Insert(index, product);
                    }
                    else
                    {
                        var index = Products.IndexOf(product);
                        Products.Remove(product);
                        Products.Insert(index, product);
                    }
                   
                }
    
    
    
        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
                {
                    var product = e.Item as Product;
                    var vm = BindingContext as MainViewModel;
        
                    if (string.IsNullOrEmpty(searchbar.Text))
                    {
                        vm.searchProducts = new ObservableCollection<Product>();
                    }
                  
                    vm?.ShowOrHidePoducts(product);
                }
    
    
    
    
     
    
        private void onsearchchanged(object sender ,TextChangedEventArgs e)
                {
                    var vm = BindingContext as MainViewModel;
        
                    if (string.IsNullOrEmpty(e.NewTextValue))
                        windowslistview.ItemsSource = vm?.Products;
                    else
                    {
                        if (!string.IsNullOrEmpty(e.NewTextValue))
                        {
        
                            var detailsdata = vm?.Products.Where(i =>
                       i.Name.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
        
                            if(detailsdata !=null && detailsdata.Count> 0)
                            {
                                ObservableCollection<Product> myCollection = new ObservableCollection<Product>(detailsdata as List<Product>);
                                vm.searchProducts = myCollection;
                                windowslistview.ItemsSource = detailsdata;
                            }
                            else
                            {
                                windowslistview.ItemsSource = vm?.Products;
                            }
                        }
        
                    }
        
                }
