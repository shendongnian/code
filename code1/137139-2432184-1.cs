    public class OwnerView {
        
        public OwnerView() {
            _childView = new ChildView(myServiceReference);
        }
        public void CloseChildView() {
            if (childView != null) {
                _childView.Close();
                _childView.Dispose();
            }
            _childView = null;
        }
        private IChildView _childView;
    }
    public class ChildView : IChildView {
        public ChildView(MyService serviceRef) {
            _serviceRef = serviceRef;
            _serviceRef.GetSettingsAsyncFinished += new EventHandler(someEventHandler);
        }
        public void IDisposable.Dispose() {
            _serviceRef -= someEventHandler;
        }
        private MyService _serviceRef;
    }
    public interface IChildView : IDisposable {
        void DoSomething();
        ... etc ...
    }
