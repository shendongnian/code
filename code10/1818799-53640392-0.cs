    public interface IPiece
    {
        int Points { get; }
        char Letter { get; }
    }
    public class King : IPiece
    {
        public int Points => 0;
        public char Letter => 'K';
    }
