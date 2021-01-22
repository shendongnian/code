    public interface IAllThatYouNeed
    {
        public void DoSomeStuff();
    }
    public class A : IAllThatYouNeed
    {
        public void Init() {
            // do stuff
        }
    }
    public class B : IAllThatYouNeed
    {
        public void Init(int info) {
            // do stuff
        }
    }
