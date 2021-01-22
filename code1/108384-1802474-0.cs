    public class MyViewModel
    {
        private readonly IMyDependency _myDependency;
    
        public MyViewModel(IMyDependency myDependency)
        {
            _myDependency = myDependency;
        }
    }
