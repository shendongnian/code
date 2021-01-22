    class EnumerableWrapper {
        private readonly TheObjectType obj;
    
        public EnumerableWrapper(TheObjectType obj) {
            this.obj = obj;
        }
    
        public IEnumerator<YourType> GetEnumerator() {
            return obj.TheMethodReturningTheIEnumerator();
        }
    }
    
    // Called like this:
    
    foreach (var xyz in new EnumerableWrapper(yourObj))
        …;
