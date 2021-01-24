    private async void EventList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item= e.Item as Model;
            if (item!= null)
            {
                await Navigation.PushAsync(new EventDetail(item));
            }
        }
