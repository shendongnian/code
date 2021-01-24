     private async void FetchInvoicesDataFunc(object sender, RoutedEventArgs e)
     {
       List<Invoice> results = new List<Invoice>();
       ProgressBtn.Content = "Loading Data ...";
       await Task.Run(async() => results.AddRange(await FetchInvoiceDataAsync(0, 500));  
       ProgressBtn.Content = "25% done...";
       await Task.Run(async() => results.AddRange(await FetchInvoiceDataAsync(501, 1000)); 
       ProgressBtn.Content = "50% done...";
       await Task.Run(async() => results.AddRange(await FetchInvoiceDataAsync(1001, 1500)); 
       ProgressBtn.Content = "75% done...";
       await Task.Run(async() => results.AddRange(await FetchInvoiceDataAsync(1501, 2000));        
       InvoiceGrid.ItemsSource = results;
       ProgressBtn.Content = "Loaded !";    
     }
    
     private async Task<List<Invoice>> FetchInvoiceDataAsync(int start, int end)
     {
       List<Invoice> result;
       using(var context = new Intelliventory_DBEntities() )
       {  
         result  = await context.Invoices.Where(b => b.InvoiceID >= start && b.InvoiceID <= end).Include(x => x.Customer).ToListAsync();      
       }
       return  result;
     }
    
