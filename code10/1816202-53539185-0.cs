    public Person GetPersonDetails(int id)
    {
        var person= _connection.Query<Person, TelephoneDetails, PersonDetailsRoot>(
            "SELECT p.* "/* TFirst */", td.* " +
            "FROM Person p " +
            "INNER JOIN TelephoneDetails td ON p.PersonContactId = td.ContactId " +
            "WHERE Id = @id",
            (person /* This is first to match the TFirst*/, details) => new PersonDetailsRoot // The new class made
            {
                PersonName = person.Adviser,
                TelephoneNumber = detail.Detail
            },
            new {id},
            splitOn: "ContactId"
        ).ToList();
        if (!person.Any())
        {
            return null;
        }
        return new PersonDetails();
