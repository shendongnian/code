    public static IEnumerable<object[]> GetPersonFromDataGenerator()
    {
        var listOfPersons = GetList();
        yield return listOfPersons.ToArray();
    }
