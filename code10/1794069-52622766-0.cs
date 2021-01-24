        public class User
        {
            public string Name { get; set; }
        }
      public List<User> users = new List<User>();
      
      users.Add(new User() { Name = "dogs" });
      users.Add(new User() { Name = "dog" });
      users.Add(new User() { Name = "cat" });
      users.Add(new User() { Name = "cats" });
     this.dataGrid1.ItemsSource = users;
      <DataGrid Height="179" HorizontalAlignment="Left" Margin="54,65,0,0" Name="dataGrid1" VerticalAlignment="Top" Width="382">
            </DataGrid>
