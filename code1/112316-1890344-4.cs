    class CustomFS : FS
    {
        private StuffGetter _stuffGetter { get; set; }
        public CustomFS(StuffGetter stuffGetter)
        {
            _stuffGetter = stuffGetter;
        }
        protected override int GetStuff(int x)
        {
            int retval = base.GetStuff(x);
            return _stuffGetter.GetStuff(retval);
        }
    }
    class CustomFS2 : FS2
    {
        private StuffGetter _stuffGetter { get; set; }
        public CustomFS2(StuffGetter stuffGetter)
        {
            _stuffGetter = stuffGetter;
        }
        protected override int GetStuff(int x)
        {
            int retval = base.GetStuff(x);
            return _stuffGetter.GetStuff(retval);
        }
    }
