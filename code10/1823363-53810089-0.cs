     public event EventHandler SomePropertychanged;
        private int _SomeProperty;
        public int SomeProperty
        {
            get
            {
                return this._SomeProperty;
            }
            set
            {
                if (this._SomeProperty != value)
                    SomePropertychanged?.Invoke(this, new EventArgs());
            }
        }
