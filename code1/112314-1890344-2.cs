    class CustomFS : FS
    {
        private StuffGetter StuffGetter { get; set; }
        public CustomFS(StuffGetter stuffGetter)
        {
            StuffGetter = stuffGetter;
        }
        protected override int GetStuff(int x)
        {
            int retval = base.GetStuff(x);
            return StuffGetter.GetStuff(retval);
        }
    }
    class CustomFS2 : FS2
    {
        private StuffGetter StuffGetter { get; set; }
        public CustomFS2(StuffGetter stuffGetter)
        {
            StuffGetter = stuffGetter;
        }
        protected override int GetStuff(int x)
        {
            int retval = base.GetStuff(x);
            return StuffGetter.GetStuff(retval);
        }
    }
