    public class MyState 
    { 
        private bool _method1HasExecuted;
        private bool _method2HasExecuted;
        private bool _method3HasExecuted;
        public bool Method1HasExecuted
        {
            get
            {
                return _method1HasExecuted;
            }
            set
            {
                _method1HasExecuted = value;
            }
        }
        public bool Method2HasExecuted
        {
            get
            {
                return _method2HasExecuted;
            }
            set
            {
                _method2HasExecuted = value;
            }
        }
        public bool Method3HasExecuted
        {
            get
            {
                return _method3HasExecuted;
            }
            set
            {
                _method3HasExecuted = value;
            }
        }
    } 
