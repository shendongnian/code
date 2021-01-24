    public class CannotBeMutated
    {
        private string someVal;
        public CannotBeMutated(string someVal)
        {
            _someVal = someVal
        }
        public string SomeVal => _someVal;
    }
