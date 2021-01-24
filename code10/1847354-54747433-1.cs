    public class CustomAnimal : Animal
    {
        public Action RunAction { get; set; }
    
        public override void Run()
        {
            RunAction();
        }
    }
