    public class ActionerOnA
    {
        private A _a;
        private Action<A> _actionToExecute;
        public ActionerOnA(Action<A> action, A a) 
        {
            _a = a;
            _actionToExecute = action;
        }
        public ActionerOnA(Action<A> action, B b) : this(action, b.ToA()) { }
        public ActionerOnA(Action<A> action, int x, int y, int z) : this(action, new A(x, y, z)) { }
    }
