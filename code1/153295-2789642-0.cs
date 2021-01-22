    public class MyClass
    {
        public static event EventHandler MyEvent;
        private static void RaiseEvent()
        {
            var handler = MyEvent;
            if (handler != null)
                handler(typeof(MyClass), EventArgs.Empty);
        }
    }
