    public struct Whatsit
    {
        public int Foo { set; get; }
        public double Bar { set; get; }
        public bool initialized;
    
        public Whatsit(int f, double b) : this()
        {
            initialized = true;
            Foo = f; Bar = b;
        }
    }
    // Add to the Demo class above.
    static void ShowWhatsit(Whatsit s = default(Whatsit))
    {
        Whatsit ss = s.initialized ? s : new Whatsit(1, 2.3);
        Console.WriteLine("Whatsit: Foo = {0}; Bar = {1}; initialized = {2}",
            ss.Foo, ss.Bar, ss.initialized);
    }
