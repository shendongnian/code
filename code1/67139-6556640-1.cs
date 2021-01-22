    class Operator : IOperator
    {
        public Operator(){}
        
        public Operator(int id, string name, bool isAdmin)
        {
            this.ID = id;
            this.Name = name;
            thsi.IsAdmin = isAdmin;
        }
    
        public int ID { get; set; }
        public string name { get; set; }
        public bool IsAdmin { get; set; }
    }
