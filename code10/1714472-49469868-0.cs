    public abstract class Card
    {
        public int Index { get; private set; }
        public string Front { get; private set; }
        public string Back { get; private set; }
        public Card(int index, string front, string back)
        {
            this.Index = index;
            this.Front = front;
            this.Back = back;
        }
    }
    public class FearCard : Card
    {
        public FearCard(int index, string front, string back) : base(index, front, back) { }
    }
    public class EventCard : Card
    {
        public EventCard(int index, string front, string back) : base(index, front, back) { }
    }
    public class InvaderCard : Card
    {
        public InvaderCard(int index, string front, string back) : base(index, front, back) { }
    }
    public class BlightCard : Card
    {
        public BlightCard(int index, string front, string back) : base(index, front, back) { }
    }
