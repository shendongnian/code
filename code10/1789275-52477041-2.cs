    private async void ItemView_ItemClick(object sender, ItemClickEventArgs e)
    {
        AvaibleRes.IsOpen = true;
        video item = e.ClickedItem as video;
        DetailJudul.Text = item.judul;
        ResolutionList.ItemsSource = rootObject.videos.Where(x => x.judul == item.judul).ToList();
    }
