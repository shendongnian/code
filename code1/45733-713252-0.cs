    class Column 
    {
        private string name, value;
        public string Name {
           get { return this.name; }
           set { this.name= MyPool.Get(value); }
        }
        public string Value{
           get { return this.value; }
           set { this.value = MyPool.Get(value); }
        }
    }
