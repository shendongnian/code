    public void Disappearing()
    {
        // Unsubscribe from events here because this is the class where you register them
        MessagingCenter.Unsubscribe<SortingOptionsViewModel>(this, "UpdateHomeList");
        MessagingCenter.Unsubscribe<ProductDetailsViewModel, string>(this, "ShoppingCartCount");
    }
