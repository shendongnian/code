    public abstract class FourLeggedAnimal
    {
    
        public void Walk()
        {
            // most 4 legged animals walk the same (silly example, but it works)
        }
    
        public void Chew()
        {
    
        }
    }
    
    public class Dog : FourLeggedAnimal
    {
        public void Bark()
        {
        }
    }
    
    public class Cat : FourLeggedAnimal
    {
        public void Purr()
        {
        }
    }
