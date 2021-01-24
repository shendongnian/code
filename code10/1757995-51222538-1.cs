    private void TheList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      if (e.LeftButton == MouseButtonState.Pressed)
      {
        MyItem item = TheList.SelectedItem as MyItem;
        if (item != null)
        {
          item.SwapStatus();
          TheList.SelectedIndex = -1;
        }
      }
    }
