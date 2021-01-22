     public class ClassBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class ClassA : ClassBase
    {
        public int JustNumber { get; set; }
        private new string Name { get { return base.Name; } set { base.Name = value; } }
        public ClassA()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.JustNumber = string.Empty;
        }
    }
