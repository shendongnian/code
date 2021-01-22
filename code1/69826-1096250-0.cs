    public class Wrapper
    {
        public int this[int i] { get { return i * 2; } }
    }
    ...
    public Wrapper pal { get { return _someWrapperInstance; } }
