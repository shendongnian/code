    public class Tetris {
    
        private IPieceGenerator pieceGenerator;
        private IFallingPiece fallingPiece;
        private IFallingPieceGenerator fallingPieceGenerator;
    
        public Tetris(IPieceGenerator pieceGenerator, IFallingPieceGenerator fallingPieceGenerator) {
          this.pieceGenerator = pieceGenerator;
          this.fallingPieceGenerator = fallingPieceGenerator;
    
        }
    
        protected void someMethodThatNeedsAFallingPiece() {
          if (fallingPiece == null) {
              IPiece piece = pieceGenerator.Generate();
              fallingPiece = fallingPieceGenerator.generate(piece);
          }
    
        }
    
    }
