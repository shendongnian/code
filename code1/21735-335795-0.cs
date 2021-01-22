    public static class Extensions {
        public static void Try(this Action a, int maxTries) {
           new (Func<bool>(() => { a(); return true; })).Try(maxTries);
        }
        public static TResult Try<TResult>(this Func<TResult> f, int maxTries) {
           Exception lastException = null;
           for (int i = 0; i < maxTries; i++) {
              try {
                  return f();
              } catch (Exception ex) {
                  lastException = ex;
              }
           }
           throw lastException;
        }
    }
