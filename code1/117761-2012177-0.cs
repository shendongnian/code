        public KeyEvent(eventmethod D)
            : this(null, D, null)
        {
        }
        public KeyEvent(Keys[] keys, eventmethod D)
            : this(keys, D, null)
        {
        }
        public KeyEvent(eventmethod D, object[] args)
            : this(null, D, args)
        {
        }
        public KeyEvent(Keys[] keys, eventmethod D, object[] args) {
            this.args = args;
            this.keys = keys;
            em = D;
        }
