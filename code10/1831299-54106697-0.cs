            void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if(e.Item == null) {
                return;
            }
            var selectedItem = (Item) e.Item; // model
            Navigation.PushAsync(new newsITEM(selectedItem)); // pass the selected whole item from list to DetaiPage 'selectedItem' using constructor
            ((ListView)sender).SelectedItem = null;
        }
