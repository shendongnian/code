    Expression<Func<Person, string>> simpleExp = p => p.FirstName;
    Expression<Func<Person, string>> complexExp = p => p.Address.State.Abbreviation;
    Expression<Func<Person, object>> ageExp = p => p.Age;
    Console.WriteLine(GetFullPropertyName(simpleExp));
    Console.WriteLine(GetFullPropertyName(complexExp));
    Console.WriteLine(GetFullPropertyName(ageExp));
