    public class FeedResponseStub<T> : FeedResponse<T> {
        private string token;
        public FeedResponseStub(IEnumerable<T> result, string token)
            : base(result) {
            this.token = token;
        }
        public new string ResponseContinuation {
            get {
                return token;
            }
        }
    }
