    public abstract class Singleton<T> where T : Singleton<T> {
        private const string ErrorMessage = " must have a parameterless constructor and all constructors have to be NonPublic.";
        private static T instance = null;
        public static T Instance => instance ?? (instance = Create());
        protected Singleton() {
            //check for public constructors
            var pconstr = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            //tell programmer to fix his stuff
            if (pconstr.Any())
                throw new Exception(typeof(T) + ErrorMessage);
        }
        private static T Create() {
            try {
                //get nonpublic constructors
                var constructors = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                //make sure there is but 1 and use that
                return (T)constructors.Single().Invoke(null);
            }
            catch {
                //tell programmer to fix his stuff
                throw new Exception(typeof(T)+ErrorMessage);
            }
        }
    }
