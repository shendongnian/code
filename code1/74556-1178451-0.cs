    public class Animal
    {
        public virtual string Name { get; set; }
        public virtual string Species { get; set; }
    }
    
    public sealed class NullAnimal : Animal
    {
        public override string Name
        {
            get{ return string.Empty; }
            set { ; }
        }
        public override string Species
        {
            get { return string.Empty; }
            set { ; }
        }
    }
