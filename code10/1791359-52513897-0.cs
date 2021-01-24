    void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                item.IsVisible = false; //this would make the clicked item invisible
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
