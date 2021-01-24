    public List<Person> Persons { get; set; } = new List<Person>() { new Person() { Name = "Glenn Versweyveld" }, new Person() { Name = "John Do" } };
    private Command<Person> _doCommand;
    public Command<Person> DoCommand => _doCommand ?? (_doCommand = new Command<Person>((Person obj) => HandlePerson(obj)));
    private void HandlePerson(Person obj)
    {
    }
