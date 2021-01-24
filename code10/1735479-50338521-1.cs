        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LeaderTextBox.ItemsSource = new List<Employee>()
            {
                new Employee {Name = "Bob" },
                new Employee { Name = "Paul" },
                new Employee {Name = "Alex" },
            };
            ProjectLeader = new Employee {Name = "Paul" };
        }
