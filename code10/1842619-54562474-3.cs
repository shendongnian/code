    public Person(string name, Gender gender)
    {
         Name = name ?? throw new ArgumentNullException(name);
         Gender = gender;
    }
