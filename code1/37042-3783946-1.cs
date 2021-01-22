    template <typename T=ISnapshot>
    public class Cache {
        private T _lastest_snapshot;
    
        public T LatestSnapshot {
            get { return this._lastest_snapshot; }
            private set { this._latest_snapshot = value; }
        }
    
        public Cache() {
            this.LatestSnapshot = new Snapshot();
        }
    
        public void Freeze(IUpdates Updates) {
            T _next = this.LastestSnapshot.CreateNext();
            _next.FreezeFrom(Updates);
            this.LastestSnapshot = _next;
        }
    
    }
