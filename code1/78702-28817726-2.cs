    // interface implementation publisher
    public delegate void eiSubjectEventHandler(eiSubject subject);
    public interface eiSubject
    {
        event eiSubjectEventHandler OnUpdate;
        void GenereteEventUpdate();
    }
    // class implementation publisher
    class ecSubject : eiSubject
    {
        private event eiSubjectEventHandler _OnUpdate = null;
        public event eiSubjectEventHandler OnUpdate
        {
            add
            {
                lock (this)
                {
                    _OnUpdate -= value;
                    _OnUpdate += value;
                }
            }
            remove { lock (this) { _OnUpdate -= value; } }
        }
        public void GenereteEventUpdate()
        {
            eiSubjectEventHandler handler = _OnUpdate;
            if (handler != null)
            {
                handler(this);
            }
        }
    }
    // interface implementation subscriber
    public interface eiObserver
    {
        void DoOnUpdate(eiSubject subject);
    }
    // class implementation subscriber
    class ecObserver : eiObserver
    {
        public virtual void DoOnUpdate(eiSubject subject)
        {
        }
    }
