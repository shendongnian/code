    IEnumerable<IPublicPersonData> publicData = ...
    IEnumerable<ISecretPersonData> secretData = ...
    // Join these two sequences on same Id. Return as an IPerson
    IEnumerable<IPerson> joinedPerson = publicData       // take the public data
        .Join(secretData,                                // inner join with secret data
        publicPerson => publicPerson.Id,                 // from every public data take the Id
        secretPerson => secretPerson.Id,                 // from every secret data take the Id
        (publicPerson, secretPerson) => new PersonData() // when they match make a new PersonData
        {
             PublicPersonData = publicPerson,
             SecretPersnData = secretPerson,
        });
