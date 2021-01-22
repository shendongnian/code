    public PersonName[] ShowName()
    {
        LinqToEbuboo_20DataContext db = new LinqToEbuboo_20DataContext();
        var myusers = from u in db.db_users
            where u.uid > 13
            select new PersonName { FirstName = u.firstname, LastName = u.lastname };
            return myusers.ToArray();
    }
    public class PersonName {
        public string FirstName { get; set; };
        public string LastName { get; set; };
    }
