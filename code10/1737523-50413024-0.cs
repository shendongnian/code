    public override void ViewWillLayoutSubviews()
    {
       base.ViewWillLayoutSubviews();
        foreach (var item in TabBar.Items)
        {
            item.Image = GetTabIcon(item.Title);
            item.SelectedImage = GetTabIcon(item.Title);                                   
        }
    }
