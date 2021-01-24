    async void Results_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
    
            var prediction = (AutoCompletePrediction)e.SelectedItem;
    
            search_bar.Text = prediction.Name? // Your property here
          
            results_list.SelectedItem = null;
    
            var place = await Places.GetPlace(prediction.Place_ID, GooglePlacesApiKey);
    
            if (place != null)
                await DisplayAlert(
                    place.Name, string.Format("Lat: {0}\nLon: {1}", place.Latitude, place.Longitude), "OK");
    
        } 
