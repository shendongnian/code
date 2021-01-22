    public class CardDealer {
    ...
      private List<Card> _deck;
    
      // Put the card [c] into [hand], and remove it from the deck.
      public class Deal(List<Card> hand, Card c) {
        _deck.Remove(c);
        hand.Add(c);
      }
    }
