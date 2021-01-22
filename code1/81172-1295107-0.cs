        public class Contact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }
        ...
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        dataGrid.ItemsSource = contacts;
        ...
