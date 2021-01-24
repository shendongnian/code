    private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
         var cv = CollectionViewSource.GetDefaultView(dgDetailedRecordList.ItemsSource);
         if (txtSearch.Text != String.Empty)
         {
             textSearch = sender as TextBox;
             filterText = textSearch.Text;  
             if (filterText != null)
             {
                 // Existing filter here     
             }
         }
         else
         {
            cv.Filter = null;
         }
    }
