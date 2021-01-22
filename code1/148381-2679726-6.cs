    public struct Whatsit
    {
        public int Foo { set; get; }
        public double Bar { set; get; }
    
        public Whatsit(int f, double b) : this()
        {
            Foo = f; Bar = b;
        }
    }
    static void ShowWhatsit(Whatsit? s = null)
    {
        Whatsit ss = s ?? new Whatsit(1, 2.3);
        Console.WriteLine("Whatsit: Foo = {0}; Bar = {1}",
            ss.Foo, ss.Bar);
    }
