    class CustomFS : FS
    {
        private StuffGetter { get; set; }
        public CustomFS(StuffGetter stuffGetter)
        {
            StuffGetter = stuffGetter;
        }
        protected override int GetStuff(int x)
        {
            int retval = base.GetStuff(x);
            return stuffGetter.GetStuff(retval);
        }
    }
