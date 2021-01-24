        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var paul = new Employee { Name = "Paul" };
            LeaderTextBox.ItemsSource = new List<Employee>()
            {
                new Employee {Name = "Bob" },
                paul,
                new Employee {Name = "Alex" },
            };
            ProjectLeader = paul;
        }
