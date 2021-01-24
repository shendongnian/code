    public interface IAnimal
    {
        int LegCount { get; }
    }
    
    public abstract class Animal: IAnimal
    {
         public virtual int LegCount {get{return 4;}}   
    
         public event EventHandler<AnimalRequiredEventArgs<Animal>> AnimalRequired;
    
         protected virtual void OnAnimalRequired(AnimalRequiredEventArgs e)
            {
                // Make a temporary copy of the event to avoid possibility of
                // a race condition if the last subscriber unsubscribes
                // immediately after the null check and before the event is raised.
                EventHandler<AnimalRequiredEventArgs<Animal>> handler = AnimalRequired;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
    }
    
    public class Dog : Animal
    {
        public override int LegCount { get { return 4; } }
    }
    
    public class Octopus : IAnimal
    {
        public override int LegCount { get { return 8; } }
    }
