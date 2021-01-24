    public class Field
    {
        public Piece Piece { get; private set; }
        public void SetPiece(Piece piece)
        {
            if (piece != null)
            {
                var otherField = piece.Field;
                if (otherField?.Piece == piece)
                {
                    otherField.SetPiece(null);
                }
            }
            Piece = piece;
        }
    }
    public class Piece
    {
        public Field Field { get; set; }
        public void MoveTo(Field field)
        {
            if (field != null)
            {
                var otherPiece = field.Piece;
                if (otherPiece?.Field == field)
                {
                    otherPiece.MoveTo(null);
                }
            }
            Field = field;
        }
    }
