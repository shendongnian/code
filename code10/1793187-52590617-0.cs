    public static IEnumerable<IPerson> LiteralJoinPersonData(List<IPublicPersonData> publics, List<ISecretPersonData> secrets)
    {
        return from p in publics
                join s in secrets on p.PersonId equals s.PersonId
                select new Person(p.PersonId, p.Name, s.AnnualSalary);
    }
    public static IEnumerable<IPerson> FunctionalJoinPersonData(List<IPublicPersonData> publics, List<ISecretPersonData> secrets)
    {
        return publics
            .Join<IPublicPersonData, ISecretPersonData, int, IPerson>(
                secrets,
                p => p.PersonId,
                s => s.PersonId,
                (p, s) => new Person(p.PersonId, p.Name, s.AnnualSalary));
    }
