    public class Foo {
        public static void DoSomethingAsynchronous(SimpleCallback simpleCallback) {
            // First this method does something asynchronous
            // Then it calls the provided delegate, passing the operation's results
            simpleCallback(true);
        }
    }
    // The result parameter can be much richer - it's your primary mechanism for
    // passing results back to the caller.
    public delegate SimpleCallback(bool result);
