    public class ClassBase
    {
        public int ID { get; set; }
    
        public string Name { get; set; }
    }
    
    public class ClassA
    {
        private ClassBase _base;
        public int ID { get { return this._base.ID; } }
    
        public string JustNumber { get; set; }
    
        public ClassA()
        {
            this._base = new ClassBase();
            this._base.ID = 0;
            this._base.Name = string.Empty;
            this.JustNumber = string.Empty;
        }
    }
