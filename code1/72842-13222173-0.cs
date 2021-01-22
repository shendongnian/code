    //The shuffle goes like this: you take a portion of the deck, then put them in random places
    private void Shuffle()
    {
     int length = DeckofCards.Count;
     int level = 20; //number of shuffle iterations
     List<Card> Shuffleing; //the part of the deck were putting back
     Random rnd = new Random();
     int PickedCount, BackPortion; //the last used random number
     for (int _i = 0; _i < level; _i++)
     {
      PickedCount = rnd.Next(10, 30); //number of cards we pick out
      Shuffleing = DeckofCards.GetRange(0, PickedCount);
      DeckofCards.RemoveRange(0, PickedCount);
      while (Shuffleing.Count != 0)
      {
       PickedCount = rnd.Next(10, DeckofCards.Count - 1); //where we place a range of cards
       BackPortion = rnd.Next(1, Shuffleing.Count / 3 + 1); //the number of cards we but back in one step
       DeckofCards.InsertRange(PickedCount, Shuffleing.GetRange(0, BackPortion)); //instering a range of cards
       Shuffleing.RemoveRange(0, BackPortion); //we remove what we just placed back
      }
     }
    }
