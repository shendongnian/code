    public class Question
    {
        //define the "enum" values
        public static readonly Question Role = new Question(2,"Role");
        public static readonly Question ProjectFunding = new Question(3, "Project Funding");
        public static readonly Question TotalEmployee = new Question(4, "Total Employee");
        public static readonly Question NumberOfServers = new Question(5, "Number of Servers");
        public static readonly Question TopBusinessConcern = new Question(6, "Top Business Concern");
        
        //attributes
        protected int index;
        protected string name;
        //protected static readonly ICollection<Question> values = new Collection<Question>();
        protected static readonly IDictionary<int,Question> values = new Dictionary<int,Question>(); //go with a dictionary to enforce unique index
        
        //constructors
        protected Question(int index, string name)
        {
            this.index = index;
            this.name = name;
            values.Add(index, this);
        }
        //easy int conversion
        public static implicit operator int(Question index)
        {
            return index.index;
        }
        public static implicit operator Question(int index)
        {
            //return values.FirstOrDefault(item => index.Equals(item.index));
            Question result;
            values.TryGetValue(index, out result);
            return result;
        }
    }
