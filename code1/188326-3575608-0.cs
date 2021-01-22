    listView1.Columns.Add("Image");
    listView1.Columns.Add("Text1");
    listView1.Columns.Add("Text2");
    listView1.SmallImageList = imageList1;
    
    var icon = Icon.ExtractAssociatedIcon(@"c:\windows\explorer.exe");
    imageList1.Images.Add(icon);
    var item = new ListViewItem();
    item.ImageIndex = 0;
    var subItem1 = new ListViewItem.ListViewSubItem();
    subItem1.Text = "Text 1";
    var subItem2 = new ListViewItem.ListViewSubItem();
    subItem2.Text = "Text 2";
    item.SubItems.Add(subItem1);
    item.SubItems.Add(subItem2);
    listView1.Items.Add(item);
