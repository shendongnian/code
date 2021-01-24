    public enum ChessPieces
    {
        King, Queen, Rook, // ... etc. 
    }
    public class ChessPiece : MonoBehavior
    {
        public string FenId { get; }
        private readonly Dictionary<ChessPiece, string> FenIds = {
            { ChessPieces.King, "K" },
            { ChessPieces.Queen, "Q" },
            // ... etc.
        };
        // assuming you create the set of pieces programatically, use this constructor
        public ChessPiece(ChessPiece piece, ChessColor color)
        {
            FenId = color == ChessColor.Black 
                ? FenIds[piece].ToLower() 
                : FenIds[piece].ToUpper();
        }
    }
