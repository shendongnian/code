    public class Foo
    {
        DoObservable _doValues = new DoObservable();
        public IObservable<String> DoValues
        {
            return _doValues;
        }
        public string Do(int param)
        {
            string result;
            // whatever
            _doValues.Notify(result);
        }
    }
    public class DoObservable : IObservable<String>
    {
        List<IObserver<String>> _observers = new List<IObserver<String>>();
        public void Notify(string s)
        {
            foreach (var obs in _observers) obs.OnNext(s);
        }
        public IObserver<String> Subscribe(IObserver<String> observer)
        {
            _observers.Add(observer);
            return observer;
        }
    }
