        interface IBar {
            IEnumerator<string> GetEnumerator();
        }
    
        class Foo : IBar {
            
            // default iterator
            public IEnumerator<int> GetEnumerator()
            {
                yield return 1;
            }
            
            // explicitly implemented interface
            IEnumerator<string> IBar.GetEnumerator()
            {
                yield return "hello";
            }
            
            // more iterators 
            public IEnumerable<string> AnotherIterator()
            {
                yield return "hello2";
            }
        }
    
            interface IBar {
        IEnumerator<string> GetEnumerator();
    }
    class Foo : IBar, IEnumerable<int> {
        
        public IEnumerator<int> GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }
        IEnumerator<string> IBar.GetEnumerator()
        {
            yield return "hello";
        }
        public IEnumerable<string> AnotherIterator()
        {
            yield return "hello2";
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); 
        }
    }
