    void Main()
    {
        var person = new Person();
    
        Console.WriteLine(person.HasChanged(nameof(Person.FirstName))); // false
        Console.WriteLine(person.HasChanged(nameof(Person.LastName))); // false
        Console.WriteLine(person.HasChanged(nameof(Person.LikesChocolate))); // false
    
        person.FirstName = "HisFirstname";
        person.LikesChocolate = true;
    
        Console.WriteLine(person.HasChanged(nameof(Person.FirstName))); // true
        Console.WriteLine(person.HasChanged(nameof(Person.LastName))); // false
        Console.WriteLine(person.HasChanged(nameof(Person.LikesChocolate))); // true
    }
    
    public class Person : ChangeTrackable
    {
        private string _firstName;
        private string _lastName;
        private bool _likesChocolate;
        
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
    
        public bool LikesChocolate
        {
            get { return _likesChocolate; }
            set { SetProperty(ref _likesChocolate, value); }
        }
    }
    
    public class ChangeTrackable
    {
        private ConcurrentDictionary<string, bool> _changes =
           new ConcurrentDictionary<string, bool>();
    
        public bool HasChanged(string propertyName)
        {
            return _changes.TryGetValue(propertyName, out var isChanged)
                       ? isChanged : false;
        }
    
        public void ResetChanges()
        {
           _changes.Clear();
        }
        
        protected void SetProperty<T>(
            ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (!Equals(storage, value))
            {
                _changes[propertyName] = true;
            }
        }
    }
