    public interface IFilter { IEnumerable RetreiveFilter(string filterValue); }
    public class FirstNameFilter : IFilter
    {
        private const string FILTER_TYPE_NAME = "First Name";
        public IEnumerable RetreiveFilter(string filterValue)
        {
            return _myData.Where(person => person.FirstName = filtervalue);
        }
        
        public override string ToString()
        {
            return FILTER_TYPE_NAME;
        }
    }
