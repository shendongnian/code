    private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
    
            var index = forums.Results.IndexOf(e.Item as Forums.Result);
            var selectedItem = (Forums.Result)e.Item;
            if(selectedItem != null)
            {
               DisplayAlert("Alert", selected|Item.Name, "OK");
            }
            
        }
