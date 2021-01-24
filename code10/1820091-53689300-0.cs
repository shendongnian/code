     private void Add_Click(object sender, RoutedEventArgs e)
      {
         List<Car> mySelectedItems = new List<Car>();
         foreach (Car item in mainview.SelectedItems)
         {
            mySelectedItems.Add(item);
         }
         Frame.Navigate(typeof(Page2), mySelectedItems);
      }
    
