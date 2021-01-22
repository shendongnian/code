    public class CancellationInfo {
        bool _Cancel = false;
        bool _Sync = new object();
        public bool Requested { get { lock(_Sync) { return _Cancel; } }
        public void Request() { lock(_Sync) _Cancel = true; }
    }
    public class ThreadActions {
        private CancellationInfo Cancel = new CancellationInfo;
        public void FirstThreadAction() {
            while(true) {
                //Process some stuff.
                if(condition)
                   Cancel.Request();
            }
        }
        public SecondThreadAction() {
            while(true) {
                if(Cancel.Requested)
                    break;
                //Process some stuff.
            }
        }
    }
