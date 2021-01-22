    interface ICardPile
    {
        ICollection<Card> Cards
        {
            get;
        }
    }
    interface IOrderedCardPile : ICardPile // FIXME Better name.
    {
    }
    class Deck : ICardPile
    {
        private Stack<Card> _cards = new Stack<Card>();
        ICollection<Card> Cards
        {
            get
            {
                return _cards;
            }
        }
    }
    class Hand : IOrderedCardPile
    {
        private HashSet<Card> _cards = new HashSet<Card>();
        ICollection<Card> Cards
        {
            get
            {
                return _cards;
            }
        }
    }
    // Extension methods
    static void MoveSomeTo(this ICardPile pile, ICardPile other, int count)
    {
        // Removes cards from the end of pile and puts them at the end of other.
        foreach(Card card in pile.Cards.Reverse().Take(count))
        {
            other.Add(card);
        }
        pile.Cards = pile.Cards.Take(count);
    }
    static void MoveCardTo(this IOrderedCardPile pile, ICardPile other, Card card)
    {
        // Removes card from pile and puts it at the end of other.
        pile.Remove(card);
        other.Add(card);
    }
