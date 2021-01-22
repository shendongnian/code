    public IEnumerable<Person> People 
    {
        get { return people; }
        set { people = value.ToList(); }
    }
    private List<People> people;
