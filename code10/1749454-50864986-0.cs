    public string Name { get; private set; }
    public string Gender { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Person(string name, string gender, DateTime birthDate)
    {
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
    }
