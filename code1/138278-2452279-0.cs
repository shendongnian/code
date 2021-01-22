    class Strings : List<String> {
        private Int32 _numberOfRemovals = 0;
    
        public Int32 NumberOfRemovals {
            get { return _numberOfRemovals; }
        }
    
        public new void Remove(String s) {
            base.Remove(s);
            _numberOfRemovals--;
        }
    }
