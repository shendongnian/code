     private string selectedText;
     private void textbox_TextChanged(object sender, EventArgs e)
     {
      selectedtext = (sender as TextBlock).Text
     }
     private void ListItems_ItemClick(object sender, ItemClickEventArgs e)
    {
     ///use selectedtext string as you want
    }
