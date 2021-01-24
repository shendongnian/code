    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        
        ViewModel.Disappearing(); // Method to unsubscribe from MessagingCenter in ViewModel
    }
