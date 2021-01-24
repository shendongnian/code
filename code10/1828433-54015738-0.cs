    namespace Java.Util
    {
        public interface IObserver : IJavaObject, IDisposable
        {
            void Update(Observable o, Lang.Object arg);
        }
    }
