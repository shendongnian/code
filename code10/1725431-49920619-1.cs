     public async void OnTesteAsync()
        {
          
            lstView_cliente.ItemsSource = await App.Database.GetEmployeesAsyncBy(searchBar_cliente.Text);
        }
       
        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            OnTesteAsync();
           
        }
