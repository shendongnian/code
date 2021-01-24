    for (int i = 0; i < MyGridView.Items.Count; i++)
    {
        if(MyGridView.Items[i] is SampleModel item && (item.ID == 2 || item.ID == 3))
        {
            var gridViewItem = MyGridView.ContainerFromItem(item);
            /// do something with this GridViewItem
        }
    }
