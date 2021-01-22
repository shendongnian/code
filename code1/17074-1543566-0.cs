    public static class Extensions {
        public static int K(this int value) {
            return value * 1024;
        }
        public static int M(this int value) {
            return value * 1024 * 1024;
        }
    }
    public class Program {
        public void Main() {
            WSHttpContextBinding serviceMultipleTokenBinding = new WSHttpContextBinding() {
                MaxBufferPoolSize = 2.M(), // instead of 2097152
                MaxReceivedMessageSize = 64.K(), // instead of 65536
            };
        }
    }
