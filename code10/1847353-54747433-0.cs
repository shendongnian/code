    public class CustomAnimal : Animal
    {
        Action RunAction { get; set; }
    
        public override void Run()
        {
            RunAction();
        }
    }
