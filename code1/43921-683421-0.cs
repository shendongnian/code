    public interface ITheInterfaceYouNeed
    {
        void DoWhatYouWant();
    }
    public class MyA : ITheInterfaceYouNeed
    {
        protected ClassA _actualA;
        public MyA( ClassA actualA )
        {
            _actualA = actualA;
        }
        public void DoWhatYouWant()
        {
            _actualA.DoWhatADoes();
        }
    }
    public class MyB : ITheInterfaceYouNeed
    {
        protected ClassB _actualB;
        public MyB( ClassB actualB )
        {
            _actualB = actualB;
        }
        public void DoWhatYouWant()
        {
            _actualB.DoWhatBDoes();
        }
    }
