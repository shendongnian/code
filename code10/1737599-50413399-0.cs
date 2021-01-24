    public class C 
    {
        public A A { get; }
        public B B { get; }
        public void UpdateInput(Action<InputBase> updateFunc)
        {
            updateFunc(A);
            updateFunc(B);
        }
    }
