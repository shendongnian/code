    public class MyObject
    {
        private string _currentState;//This will be changed only from inside class
        public string MyCurrentState
        {
           get
           {
             return _currentState;
           }
        }
    }
