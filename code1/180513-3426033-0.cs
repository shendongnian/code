    public IAwesome { string Whatever { get; } }
    public SoCool : IAwesome { public string Whatever { get; } }
    public HeyHey
    {
        public SoCool GetSoCool() { return new SoCool(); }
        public void Processy()
        {
            var blech = GetSoCool();
            IAwesome ohYeah = GetSoCool();
            // Now blech != ohYeah, so var is blech and ohYeah is IAwesome.
        }
    }
