    private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
            var ll = e.View as LinearLayout;
            var sw = ll.GetChildAt(1) as Switch;
            if (sw.Checked)
            {
                sw.Checked = false;
                adapter.changeState((int)sw.Tag,false);
            }
            else
            {
                sw.Checked = true;
                adapter.changeState((int)sw.Tag, true);
            }
    }
