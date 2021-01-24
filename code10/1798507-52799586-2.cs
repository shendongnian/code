        static void Main(string[] args)
    {
        List<Family> Families = new List<Family>();
        Adults father = new Adults { Name = "Jim", Age = 34, Job = "Programmer", LicNumber = 2344454 };
        Adults mother = new Adults { Name = "Amy", Age = 33, Job = "Nurse", LicNumber = 88888 };
        Family fam1 = new Family { Nickname = "Family One", FamilyId = 1, father = father, mother = mother ,    };
        Person child1 = new Person { Name = "Bob", Age = 4 }; 
        fam1.Children.add(child1); //Here add child to collection
        Families.Add(fam1);
        PrintFamily(fam1);  
    }
