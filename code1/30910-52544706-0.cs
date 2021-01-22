    class Person
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public override bool Equals(object obj)
        {
            return ((Person)obj).Id == Id;
            // or: 
            // var o = (Person)obj;
            // return o.Id == Id && o.Name == Name;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
