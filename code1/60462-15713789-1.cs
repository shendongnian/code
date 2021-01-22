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
        //go with a dictionary to enforce unique index
        //protected static readonly ICollection<Question> values = new Collection<Question>();
        protected static readonly IDictionary<int,Question> values = new Dictionary<int,Question>();
        
        //constructors
        protected Question(int index, string name)
        {
            this.index = index;
            this.name = name;
            values.Add(index, this);
        }
        //easy int conversion
        public static implicit operator int(Question question)
        {
            return question.index; //nb: if question is null this will return a null pointer exception
        }
        public static implicit operator Question(int index)
        {
            //return values.FirstOrDefault(item => index.Equals(item.index));
            Question question;
            values.TryGetValue(index, out question);
            return question;
        }
        //easy string conversion (also update ToString for the same effect)
        public override string ToString()
        {
            return this.name;
        }
        public static implicit operator string(Question question)
        {
            return question == null ? null : question.ToString();
        }
        public static implicit operator Question(string name)
        {
            return name == null ? null : values.Values.FirstOrDefault(item => name.Equals(item.name, StringComparison.CurrentCultureIgnoreCase));
        }
        //if you specifically want a Get(int x) function (though not required given the implicit converstion)
        public Question Get(int foo)
        {
            return foo; //(implicit conversion will take care of the conversion for you)
        }
    }
