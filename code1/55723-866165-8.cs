    interface IBar {
       IEnumerator<string> GetEnumerator();
    }
    
    class Foo : IBar, IEnumerable<int> {
        
        // Very bad, risky code. Enumerator implementations, should 
        // line up in your class design. 
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
        // must be IEnumerable if you want to support foreach 
        public IEnumerable<string> AnotherIterator
        { 
            get {
               yield return "hello2";
            }
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator(); 
        }
    }
