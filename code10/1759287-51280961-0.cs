    public class DogState : IState
    {
        public int Id => 5;
        public string Description => "Dog state!";
    }
    IState state = new DogState();
    Dog dog = (Dog) state; // Won't throw
