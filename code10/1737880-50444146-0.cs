    private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
        var ll = e.View as LinearLayout;
        var sw = ll.GetChildAt(1) as Switch;
        sw.Checked = true;
        adapter.changeState(e.Position);
    }
