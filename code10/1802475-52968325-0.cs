    abstract class Entity<T> where T : Entity<T>
    {
        public abstract int Fitness(); //Bigger the number - more fit the entity is
    
        public int MoreFitThan(T other)
        {
            return Fitness().CompareTo(other.Fitness());
        }
    }
    
    class Fish : Entity<Fish>
    {
        public int swimSpeed { get; set; }
    
        public override int Fitness()
        {
            return swimSpeed;
        }
    }
    
    class Human : Entity<Human>
    {
        public int testPoints { get; set; }
    
        public override int Fitness()
        {
            return testPoints;
        }
    }
