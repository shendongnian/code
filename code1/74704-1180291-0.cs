    public sealed class StatusCode {
        private char value;
    
        public static readonly StatusCode Unknown = new StatusCode('U');
        public static readonly StatusCode Failure = new StatusCode('F');
    
        private StatusCode(char v) {
            value = v;
        }
    
        public override string ToString() {
            return value.ToString();
        }
    
    }
Then, later in your code, you could use it like an enum: StatusCode.Unknown. You could also provide an internal method to 'parse' a received value into an object of StatusCode.
