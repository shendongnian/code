        public Suit Suit;
        public Rank Rank;
        public ulong ToCardMask();
    }
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    public enum Rank
    {
        Ace,
        Deuce,
        Trey,
        //...
        Jack,
        Queen,
        King
    }
    public class Game
    {
        public GameInfo GameInfo;
        public TableInfo TableInfo;
        public List<BettingRound> BettingRounds;
        public List<Card> CommunityCards;
        public string Rawtext;
        public bool WithHero; //??
    }
    public static class GameExtensions
    {
        public static BettingRound Flop(this Game game)
        {
            return game.BettingRounds[0];
        }
        public static List<Card> FlopCards(this Game game)
        {
            return game.CommunityCards.Take(3).ToList();
        }
    }
    public class GameInfo
    {
        public GameType GameType;
        public GameBettingStructure BettingStructure; // Limit, PotLimit, NoLimit
        public Stakes Stakes; // e.g. { $1, $2 }
        public long Id;
        public List<Seat> Seats;
    }
    enum GameType // prob change to a class for extensibility
    {
        HoldEm,
        Razz,
        StudHi,
        StudHiLo,
        OmahaHi,
        OmahaHiLo
    }
    enum GameBettingStructure
    {
        Limit,
        PotLimit,
        NoLimit
    }
    class Stakes // probably needs some tweeking for stud games (e.g. bring-in ...)
    {
        public Money Ante;
        public List<Money> Blinds;
    }
    public class Seat
    {
        public Player Player;
        public Money InitialStackAmount;
        public Money FinalStackAmount; // convienience field can be calculated
        public List<Card> Hand;
    }
    class Money
    {
        public decimal Amount;
        public Unit Unit;
    }
    enum Unit
    {
        USD,
        EUR,
        AUD,
        TournamentDollars
    }
    public class Player
    {
        public string Name;
    }
    public class TableInfo
    {
        public string Name;
    }
    public class BettingRound
    {
        public List<BettingAction> BettingActions;
    }
    public class BettingAction
    {
        public abstract Money PotSizeAfter();
        public byte SeatNumber;
    }
    public class Fold : BettingAction { }
    public class Call : BettingAction { }
    public class BringIn : BettingAction { }
    public class Complete : BettingAction { }
    public class Bet : BettingAction
    {
        public Money Amount;
    }
    public class Raise : Bet { }
