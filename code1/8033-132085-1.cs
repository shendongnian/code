        private IEnumerable<string> args;
        private ClassType originalThis;
        public ClosureEnumerator(ClassType orginalThis, IEnumerable<string> args)
        {
            this.args = args;
            this.origianlThis = originalThis;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return new Closure(originalThis, args);
        }
    }
    class Closure : IEnumerator<string>
    {
        public Closure(ClassType originalThis, IEnumerable<string> args)
        {
            state = 0;
            this.args = args;
            this.originalThis = originalThis;
        }
        private IEnumerable<string> args;
        private IEnumerator<string> enumerator2;
        private IEnumerator<string> argEnumerator;
        //Here ClassType is the type of the object that contained the method
        //This may be optimized away if the method does not access any class members
        private ClassType originalThis;
        //This holds the state value.
        private int state;
        //The current value to return
        private string currentValue;
        public string Current
        {
            get 
            {
                return currentValue;
            }
        }
    }
