    class Ö {
        public string Ä { get; set; }
        public string Å { get; set; }
        public Ö() { Å = "dear";}
        public Ö(string å) { Å = å; }    
    }
    Console.WriteLine(new Ö { Ä = "hello" }.Å);
    Console.WriteLine(new Ö("world") { Ä = "hello" }.Å);
