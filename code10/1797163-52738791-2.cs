    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    
        public override bool Equals(object obj)
        {
            if (!(obj is Animal))
                return false;
            Animal p = (Animal)obj;
            return (p.Id == Id && p.Name == Name && p.Age == Age);
        }
        public override int GetHashCode()
        {
            return String.Format("{0}|{1}|{2}", Id, Name, Age).GetHashCode();
        }
    }
