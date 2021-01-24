    class Card
    {
        // jsut delete these all together
        //private Suit suit; // you are printing this out and never changing it
        //private Face face; // you are printing this out and never changing it
    
        public Suit Suit { get; set; }
        public Face Face { get; set; }
    
        public void Print()
        {
          //  Console.WriteLine("{0} of {1}", face, suit);
          // print your actual properties not the backing fields that have never been set
          Console.WriteLine("{0} of {1}", Face, Suit);
        }
    }
