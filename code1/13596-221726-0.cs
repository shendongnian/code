        private IEnumerator<string> Enumerator() {
            // ...
        }
        public IEnumerator<string> GetEnumerator() {
            return Enumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return Enumerator();
        }
