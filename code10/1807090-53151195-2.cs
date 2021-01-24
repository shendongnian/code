    ObservableCollection<VW_Users> collection = new ObservableCollection<VW_Users>();
    object @lock = new object();
    BindingOperations.EnableCollectionSynchronization(collection, @lock);
    DataGrid_User.ItemsSource = collection;
    Task.Run(() =>
    {
        using (SqlConnection connection = new SqlConnection("connection string...."))
        {
            SqlCommand command = new SqlCommand("select * From VW_Users where GymID = @GymId", connection);
            command.Parameters.AddWithValue("GymId", PublicVar.ID + " " + SearchStringForUser());
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                const int N = 10;
                VW_Users[] cache = new VW_Users[N];
                int counter = 0;
                while (reader.Read())
                {
                    VW_Users obj = new VW_Users();
                    obj.Property1 = Convert.ToString(reader["Column1"]);
                    cache[counter] = obj;
                    //...and so on for each property...
                    if (++counter == N)
                    {
                        //add N items to the source collection
                        foreach (VW_Users x in cache) collection.Add(x);
                        counter = 0;
                        //add a delay so you actually have a chance to see that N items are added at a time
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                //add any remaining items
                for (int i = 0; i<counter; ++i) collection.Add(cache[i]);
            }
            reader.Close();
        }
    });
