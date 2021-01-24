    class WithChannel {
        public class MyEvent {
        }
        private readonly Subject<MyEvent> _event;
        public WithChannel() {
            _event = new Subject<MyEvent>();
        }
        public IObservable<MyEvent> EventRaised => _event;
        public void Foo() {
            _event.OnNext(new MyEvent());
        }
    }
