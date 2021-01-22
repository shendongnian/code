    abstract class BasePiece {
       protected BasePiece(BasePiece pieceToClone) {
          this.Color = pieceToClone.Color;
          this.CurrentSquare = pieceToClone.CurrentSquare;
       }
       public abstract BasePiece GetSimulatedClone();
    }
    class King : BasePiece {
       protected King(King pieceToClone) : base(pieceToClone) { }
       public King() { }
       public override BasePiece GetSimulatedClone() {
           return new King(this);
       }
    }
