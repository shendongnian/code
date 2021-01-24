    public class Outer
    {
        public IInner Inner = new Inner();
        public interface IInner { ... }
        private class Inner: Inner { ... }
    }
