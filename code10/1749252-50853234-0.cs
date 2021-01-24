    public static int AddPerson(TestClass testClass, Person p)
    {
        testClass.PeopleList.Add(p.Name, p);
        return testClass.PeopleList.Count;
    }
