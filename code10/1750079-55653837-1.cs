    private void OnGridLoaded(object sender, RoutedEventArgs e)
    {
        
        var vm = (sender as Grid)?.DataContext as FooVm;    
        if ((vm != null)    
        &&  (vm.IsDisplayed == false))    
        {    
            MyDataGrid.Columns.Remove(MyColumn);        
        }    
    }
   
