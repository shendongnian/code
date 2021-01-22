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
