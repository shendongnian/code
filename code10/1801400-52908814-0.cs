     public class ViewModel
        {
            ObservableCollection<Person> _items = new ObservableCollection<Person>
                {
                    new Person { Name = "P1", Age = 1 },
                    new Person { Name = "P2", Age = 2 }
                };
            public ObservableCollection<Person> Items
            {
                get
                {
                    return _items;
                }
            }
        }
