    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public ObservableCollection<Person> Childs { get; set; }
    }
