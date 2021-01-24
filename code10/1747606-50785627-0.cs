    public Person(string name, string secondName, string address, int age, DateTime birthDate)
    {
        Name = name;
        SecondName = secondName;
        Address = address;
        Age = age;
        BirthDate = birthDate;
    }
    public Person(string name, string secondName, string address, int age, DateTime birthDate, string url)
        : this (name, secondName, address, age, birthDate)
    {
        Url = url;
    }
