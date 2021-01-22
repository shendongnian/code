    public IList<Person> getPersons() {
        return from p in repository.getPersons() return p;
    }
    public IPerson getPerson(int id) {
        return repository.getDbPersons().withPersonId(id);
    }
    // Person Filter Class
    public static class PersonFilters
    {
        public static IPerson WithPersonId(this IQueryable<SqlServer.Person> qry, int Id)
        {
            return (from p in qry
                    where p.Id == Id
                    select p).Select(p => ThisPerson(p)).SingleOrDefault();
        }
        private static IPerson ThisPerson(OneToOne.Data.SqlServer.Person x)
        {
            IPerson ret;
            switch (x.TypeId)
            {
                case (int)PersonType.Employee:
                    var e = new Employee();
                    e.Id = x.Id;
                    e.Name = x.Name;
                    e.Age = x.Age.GetValueOrDefault(0);
                    e.Salary = x.Employee.Salary.GetValueOrDefault(0);
                    e.PersonType = PersonType.Employee;
                    ret = e;
                    break;
                case (int)PersonType.Student:
                    var s = new Student();
                    s.Id = x.Id;
                    s.Name = x.Name;
                    s.Age = x.Age.GetValueOrDefault(0);
                    s.Major = x.Student.Major;
                    s.PersonType = PersonType.Employee;
                    ret = s;
                    break;
                default:
                    throw new Exception("Bad Person Type");
            }
            return ret;
        }
    }
