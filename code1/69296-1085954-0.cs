    public class SharedChangeNotifier
    {
        public static event EventHandler<DataChangedEventArgs> SharedChangeEvent;
        protected void RaiseChangeEvent()
        {
            if (SharedChangeNotifier.SharedChangeEvent != null)
            {
                SharedChangeNotifier.SharedChangeEvent(
                    this, new DataChangedEventArgs());
            }
        }
    }
    public class Foo : SharedChangeNotifier
    {
        public int MyProperty
        {
            get { ... }
            set
            {
                ...
                RaiseChangeEvent();
            }
        }
    }
