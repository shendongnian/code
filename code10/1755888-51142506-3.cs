    class Program
    {
        static void Main(string[] args)
        {
            var companies = new[]
            {
                Company.Factory.Create("ABC", "Indianapolis", "In", "(317) 333 5555"),
                Company.Factory.Create("Def", "Bloominton", "In", "(812) 333 5555"),
            };
            var people = new[]
            {
                Person.Factory.Create("Jane", "Doe", "(317) 555 7565", 1),
                Person.Factory.Create("Paul", "Smith", "(812) 555 7565", 2),
                Person.Factory.Create("Sean", "Jackson", "(317) 555 7565", 2),
                Person.Factory.Create("Jenny", "Gump", "(812) 555 7565", 1)
            };
            var peopleFromIndianapolis =
            (
                from company in companies
                join person in people on company.Id equals person.CompanyId
                where person.PhoneNumber.StartsWith("(317)")
                orderby person.LastName, person.FirstName
                select new
                {
                    person.FirstName,
                    person.LastName,
                    company.Name
                }
            ).ToList();
            foreach (var person in peopleFromIndianapolis)
            {
                Console.WriteLine($"PersonName: {person.LastName}, {person.FirstName} - Company:{person.Name}");
            }
        }
    }
