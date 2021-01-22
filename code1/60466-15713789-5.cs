    public class Question
    {
        // Attributes
        protected int index;
        protected string name;
        // Go with a dictionary to enforce unique index
        //protected static readonly ICollection<Question> values = new Collection<Question>();
        protected static readonly IDictionary<int,Question> values = new Dictionary<int,Question>();
        // Define the "enum" values
        public static readonly Question Role = new Question(2,"Role");
        public static readonly Question ProjectFunding = new Question(3, "Project Funding");
        public static readonly Question TotalEmployee = new Question(4, "Total Employee");
        public static readonly Question NumberOfServers = new Question(5, "Number of Servers");
        public static readonly Question TopBusinessConcern = new Question(6, "Top Business Concern");
        
        // Constructors
        protected Question(int index, string name)
        {
            this.index = index;
            this.name = name;
            values.Add(index, this);
        }
        // Easy int conversion
        public static implicit operator int(Question question) =>
            question.index; //nb: if question is null this will return a null pointer exception
        public static implicit operator Question(int index) =>        
            values.TryGetValue(index, out var question) ? question : null;
        // Easy string conversion (also update ToString for the same effect)
        public override string ToString() =>
            this.name;
        public static implicit operator string(Question question) =>
            question?.ToString();
        public static implicit operator Question(string name) =>
            name == null ? null : values.Values.FirstOrDefault(item => name.Equals(item.name, StringComparison.CurrentCultureIgnoreCase));
        
        // If you specifically want a Get(int x) function (though not required given the implicit converstion)
        public Question Get(int foo) =>
            foo; //(implicit conversion will take care of the conversion for you)
    }
