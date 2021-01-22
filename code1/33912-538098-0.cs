    public class LoggingContext : IDisposable {
        public Finicky(string name) {
            Log.Write("Entering Log Context {0}", name);
            Log.Indent();
        }
        public void Dispose() {
            Log.Outdent();
        }
        public static void Main() {
            Log.Write("Some initial stuff.");
            try {
                using(new LoggingContext()) {
                    Log.Write("Some stuff inside the context.");
                    throw new Exception();
                }
            } catch {
                Log.Write("Man, that was a heavy exception caught from inside a child logging context!");
            } finally {
                Log.Write("Some final stuff.");
            }
        }
    }
