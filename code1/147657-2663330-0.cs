    abstract public class Animal { }
    public class Mouse : Animal { }
    public class AnimalTrap
    {
        public Animal TrappedAnimal { get; }
    }
    public class MouseTrap : AnimalTrap
    {
        new public Mouse TrappedAnimal
        {
            get { return (Mouse)base.TrappedAnimal; }
        }
    }
