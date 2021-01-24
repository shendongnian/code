    public class PeopleController : Controller
    {
        private readonly MyPeopleContext _context;
        public PeopleManager(PeopleContext context)
        {
            _context = context;
        }
        public IEnumerable<Person> Filter (int? id, string name, int? age)
        {
            var peoplequery = _context.People.AsQueryable();
            if(id.HasValue)
            {
               peoplequery = peoplequery.Where(p => p.Id == id.Value);
            }
            if(!string.IsNullOrEmpty(name))
            {
               peoplequery = peoplequery.Where(p => p.Name.Contains(name));
            }
            if(age.HasValue)
            {
               peoplequery = peoplequery.Where(p => p.Age == age.Value);
            }
            return peoplequery.ToArray();
        }
    }
