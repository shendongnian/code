public class Field
{
    public Piece piece {
        public Field field {
            public Piece piece {
                ...
            }
        }
    }
}
That's because the objects are defined in terms of each other. Then theoretically you can 
do something like
    this.field.piece.field.piece...
