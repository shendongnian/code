    // its useless now
    //DataTable Dt { get => dt; set { dt = value; dataGridAllegro.DataContext = Dt.DefaultView; } } 
    private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
    {
       buttonSearch.IsEnabled = false;
       var productName = textBoxProductName.Text; // get Text value before using Task!
       await Task.Run(() => SearchItem(productName));
       dataGridItems.ItemsSource = dt.DefaultView;
       buttonSearch.IsEnabled = true;
    }     
    
    private async void SearchItem(string ProductName)
    {
       try
       {
          var x = rest.GetTokenJ().Result;
          ItemsOffersWPF.Rootobject searchResponse = rest.requestSearchItem(ProductName);
          GetItemsCollection(searchResponse); // inside update dt not property DataTable Dt { get => dt; set { dt = value; dataGridAllegro.DataContext = Dt.DefaultView; } }
       // = exception using another thread UI
       }
       catch(Exception ex)
       {
          MessageBox.Show(ex.Message);
       }  
    }
