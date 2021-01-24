    public class ClassB()
    {
        private readonly ClassA _a;
        public ClassB(ClassA a)
        {
            _a = a;
        }
        public void FetchData(){
            a.LogMessage("Fetch data starts");
            // Use field _a instead of creating a new ClassA object.
            a.LogMessage($"Id : {_a.myID}");
            a.LogMessage("Fetch data ends");
        }
    }
