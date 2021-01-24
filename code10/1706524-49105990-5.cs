    // view model
    public ICollectionView RecipientsView
    { 
        get
        {
            if (recipientsView == null)
            {
                // DO NOT create collection view inside constructor
                recipientsView = CollectionViewSource.GetDefaultView(Recipients);
                recipientsView.Filter = // filtering code here;
            }
            return recipientsView;
        }
    }
    
    <!-- DataGrid XAML -->
    ItemsSource="{Binding RecipientsView}"
