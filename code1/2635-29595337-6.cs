    class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();
        private Mediator() { }
        public static Mediator GetInstance()
        {
            return _Instance;
        }
        public event EventHandler<PersonChangedEventArgs> PersonChanged; //this is just a property we expose to add items to the delegate.
        public void OnPersonChanged(object sender, Person p)
        {
            var personChangedDelegate = PersonChanged as EventHandler<PersonChangedEventArgs>;
            if (personChangedDelegate != null)
            {
                personChangedDelegate(sender, new PersonChangedEventArgs() { Person = p });
            }
        }
    }
