    public abstract class SmartWrap : ISmartWrap
    {
        private int orig_hashcode { get; set; }
        private bool _isInterimDirty;
        public bool IsDirty
        {
            get { return !(this.orig_hashcode == this.GetClassHashCode()); }
            set
            {
                if (value)
                    this.orig_hashcode = this.orig_hashcode ^ 108.GetHashCode();
                else
                    MakeClean();
            }
        }
        public void MakeClean()
        {
            this.orig_hashcode = GetClassHashCode();
            this._isInterimDirty = false;
        }
        // must be overridden to return combined hashcodes of fields testing for
        // example Field1.GetHashCode() ^ Field2.GetHashCode() 
        protected abstract int GetClassHashCode();
      
        public bool IsInterimDirty
        {
            get { return _isInterimDirty; }
        }
        public void SetIterimDirtyState()
        {
            _isInterimDirty = this.IsDirty;
        }
        public void MakeCleanIfInterimClean()
        {
            if (!IsInterimDirty)
                MakeClean();
        }
        /// <summary>
        /// Must be overridden with whatever valid tests are needed to make sure required field values are present.
        /// </summary>
        public abstract bool IsValid { get; }
    }
