    public class MessageChannel: IObservable<MyMessage>
    {
        class Subscription : IDisposable {
            MessageChannel _c;
            IObservable<MyMessage> _obs;
            public Subscription(MessageChannel c, IObservable<MyMessage> obs) { 
                _c = c; _obs = obs;
            }
            public void Dispose() {
                _c.Unsubscribe(_obs);
            }
        }
        public IDisposable Subscribe(IObserver<MyMessage> observer)
        {
            observers.Add(observer);
            return new Subscription(this, observer);
        }
        void Unsubscribe(IObservable<MyMessage> obs) {
            observers.Remove(obs);
        }
    }
