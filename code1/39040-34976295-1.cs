    public interface IEmployee 
    {
        public decimal Salary { get; set; }
    }
    public extension MyPersonExtension extends Person : IEmployee
    {
        private static readonly ConditionalWeakTable<Person, decimal> _salaries = new ConditionalWeakTable<Person, decimal>();
    	public decimal Salary
    	{
            get 
            {
                // `this` is the instance of Person
    		    return _salaries.GetOrCreate(this); 
            }
            set 
            {
                _salaries[this] = value; 
            }
    	}
    }
    IEmployee person = new Person();
    var salary = person.Salary;
