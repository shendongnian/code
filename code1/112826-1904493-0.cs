    public class MyCoolException : Exception {
        public MyCoolException(string msg) : base(msg) {}
    }
    public MyCoolMethod() {
        // if bad things happen
        throw new MyCoolException("You did something wrong!");
    }
