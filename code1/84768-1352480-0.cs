    static Random rnd = new Random();
    static void DoOne() { ... }
    static void DoTwo() { ... }
    static void RollDice() {
       if (rnd.Next(5) == 0)
           DoOne(); // happens 1/5 times
       else
           DoTwo(); // happens 4/5 times
    }
