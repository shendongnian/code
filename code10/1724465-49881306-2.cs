    public class FakeResult<T> : IResult<T> {
        public bool Success {
            get { return true; }
        }
    }
