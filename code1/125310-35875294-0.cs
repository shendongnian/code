    public class FooSettings
    {
        public TimeSpan Span { get; set; } = TimeSpan.FromSeconds(2);
    
        // I imagine that if you had a heavyweight default
        // thing you’d want to avoid instantiating it right away
        // because the caller might override that parameter. So, be
        // lazy! (Or just directly store a factory lambda with Func<IThing>).
        Lazy<IThing> thing = new Lazy<IThing>(() => new FatThing());
        public IThing Thing
        {
            get { return thing.Value; }
            set { thing = new Lazy<IThing>(() => value); }
        }
    
        // Another cool thing about this pattern is that you can
        // add additional optional parameters in the future without
        // even breaking ABI.
        //bool FutureThing { get; set; } = true;
    
        // You can even run very complicated code to populate properties
        // if you cannot use a property initialization expression.
        //public FooSettings() { }
    }
    
    public class Bar
    {
        public void Foo(FooSettings settings = null)
        {
            // Allow the caller to use *all* the defaults easily.
            settings = settings ?? new FooSettings();
    
            Console.WriteLine(settings.Span);
        }
    }
