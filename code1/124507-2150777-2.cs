    class Test {
        public event EventHandler Done;
        public void Start() {
            this.OnDone(new EventArgs());
        }
        protected virtual void OnDone(EventArgs e) {
            EventHandler handler = this.Done;
            if (handler != null)
                handler(this, e);
        }
    }
