    ListViewItem.ListViewSubItem mSelected;
    private void listView1_MouseMove(object sender, MouseEventArgs e) {
      var info = listView1.HitTest(e.Location);
      if (info.SubItem == mSelected) return;
      if (mSelected != null) mSelected.Font = listView1.Font;
      mSelected = null;
      listView1.Cursor = Cursors.Default;
      if (info.SubItem != null && info.Item.SubItems[1] == info.SubItem) {
        info.SubItem.Font = new Font(info.SubItem.Font, FontStyle.Underline);
        listView1.Cursor = Cursors.Hand;
        mSelected = info.SubItem;
      }
    }
