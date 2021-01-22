    public class Sum
    {
        private int _result;
    
        public int Result {
           get {
               return _result;
           }
        }
    
        public Sum(int startNum) {
            _results = startNum;
        }
    
        public void Add(int num) {
            _result += num;
        }
    }
