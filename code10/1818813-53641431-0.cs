    public interface IPiece
    {
        int Points { get; }
        char Letter { get; }
    }
    public abstract class Piece : IPiece
    {
        public abstract int Points { get; }
        public abstract char Letter { get; }
    }
    public class King : Piece
    {
        public const int POINTS = 0;
        public const char LETTER = 'K';
        public override int Points { get { return POINTS; } }
        public override char Letter { get { return LETTER; } }
    }
