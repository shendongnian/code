      private void RaiseEvent_Click(object sender, RoutedEventArgs e)
      {
         TableHandler.RaiseUpdateTableEvent();
      }
      private void MyTable_UpdateTable(object sender, RoutedEventArgs e)
      {
         MessageBox.Show("UpdateTable Attached Event Raised.");
      }
