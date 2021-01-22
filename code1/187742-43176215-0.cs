    public abstract class Singleton<T> where T : Singleton<T>, new() {
        private static readonly T s_instance = new T();
        protected Singleton() {
            if (s_instance != null) {
                string s = string.Format(
                    "An instance of {0} already exists at {0}.instance. " +
                    "That's what \"Singleton\" means. You can't create another.",
                    typeof(T));
                throw new System.Exception(s);
            }
        }
        public static T instance { get { return s_instance; } }
    }
    public class MyClass : Singleton<MyClass> {
    }
