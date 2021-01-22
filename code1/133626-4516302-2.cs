    class Product : ICloneable
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public object Clone()
        {
            return new Product() { Id=this.Id, Name=this.Name };
        }
    }
