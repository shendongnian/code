    public class AssociatesHistory
    {
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {MiddleInitial} {LastName}";
        }
    }
