listView1.VirtualMode = true;
listView1.RetreiveVirtualItem += new RetrieveVirtualItemEventHandler( this.RetrieveVirtualItem );
listView1.VirtualListSize = SampleList.Count;
private void RetreiveVirtualItem( object sender, RetrieveVirtualItemEventArgs e )
{
     ListViewItem lvItem = new ListViewItem((e.ItemIndex + 1).ToString());
     lvItem.SubItems.Add(SampleList[e.ItemIndex]);
     e.Item = lvItem;
}
