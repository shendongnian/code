    public class Animal
    {
        public abstract void DoStuff();
    }
    public Dog : Animal
    {
        public override void DoStuff()
        {
            // Do dog specific stuff here
        }
    }
    
    public Pig : Animal
    {
        public override void DoStuff()
        {
            // Do pig specific stuff here
        }
    }
