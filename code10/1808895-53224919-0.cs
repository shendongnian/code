    private async void btn1_Click(object sender, RoutedEventArgs e)
    {
        using(var connection = new SqlConnection(_cnString)
        {
            IsRefreshing = true;
            await connection.OpenAsync();
            var results=await connection.QueryAsync<Value>(query);
            //We're now back in the UI thread
            _theCollection.AddRange(results);
            IsRefreshing = false;
        }
    }
