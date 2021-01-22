    // The result parameter can be much richer - it's your primary mechanism for
    // passing results back to the caller.
    public delegate SimpleCallback(bool result);
    public class Foo {
        public static void DoSomethingAsynchronous(SimpleCallback simpleCallback) {
            // ... do something ...
            simpleCallback(true);
        }
    }
