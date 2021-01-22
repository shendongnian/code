    public class CardDealer {
    ...
      private Queue<Card> _deck;
    
      // Put the top card of the deck into the specified hand.
      public void Deal(List<Card> hand) {
        // Deck is a Queue now. No need to specify which card to take.
        Card c = _deck.Dequeue(); 
        hand.Add(c);
      }
    }
