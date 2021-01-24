    // Let's get rid of trailing spaces
    string[] name = new string[] {
      "Ace", 
      "Two",
      "Three",
      "Four",
      "Five",
      "Six",
      "Seven",
      "Eight",
      "Nine",
      "Ten",
      "Unterknave",
      "Oberknave",
      "King",
    };
    // as well as pesky "of": suit "Acorns" or "Clubs", not "of Acorns"
    string[] suits = new string[] {
      "Hearts",
      "Bells",
      "Acorns",
      "Leaves"
    };
    string[] deck;
    public Deck() {
      // All combinations of name and suits (cartesian join)
      // Avoid magic numbers like 13 (some games like preference has 8 cards in a suit)
      deck = name
        .SelectMany(n => suits.Select(s => $"{n} of {s}")) // <- space and "of" here
        .ToArray();
       
       
