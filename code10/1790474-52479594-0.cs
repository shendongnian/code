    public struct InputCodeSet
    {
        public int? primary;
        public int? secondary;
    
        public InputCodeSet(int? primary = null, int? secondary = null)
        {
            this.primary = primary;
            this.secondary = secondary;
        }
    
        public bool IsValid
        {
            get { return primary != null && primary < InputCode.MAX && secondary != null && secondary < InputCode.MAX; }
        }
    }
