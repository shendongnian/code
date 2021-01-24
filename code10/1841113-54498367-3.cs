    public class Field
    {
        public Piece Piece { get; private set; }
        public bool Occupied => Piece != null;
        public void ClearPiece()
        {
            // Remove this field from the piece
            if (Piece?.Field == this) Piece.MoveTo(null);
            // Remove the piece from this field
            Piece = null;
        }
        public void SetPiece(Piece piece)
        {
            if (piece != null)
            {
                if (Occupied)
                {
                    throw new InvalidOperationException(
                        $"Field is already occupied by {Piece}.");
                }
                // Remove piece from the piece's previous field
                if (piece.Field?.Piece == piece)
                {
                    piece.Field.ClearPiece();
                }
            }
            Piece = piece;
        }
    }
    public class Piece
    {
        public Field Field { get; private set; }
        public void MoveTo(Field field)
        {
            field.SetPiece(this);
            Field = field;
        }
    }
