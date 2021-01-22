    class Notification...
        private IList _errors = new ArrayList();
    
        public IList Errors {
          get { return _errors; }
          set { _errors = value; }
        }
        public bool HasErrors {
          get {return 0 != Errors.Count;}       
        }
