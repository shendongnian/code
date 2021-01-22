    class PieceGenerator
    {
        public void NextFallingPiece()
        {
            FallingPiece piece = new FallingPiece(NextPiece());
            return piece;
        }
        // ...
    }
    class GameEngine
    {
        public PieceGenerator pieceGenerator = new PieceGenerator();
        public void Start()
        {
            CreateFallingPiece();
        }
        void CreateFallingPiece()
        {
            FallingPiece piece = new FallingPiece(pieceGenerator.NextFallingPiece());
            piece.OnStop += piece_OnStop;
        }
        void piece_OnStop(FallingPiece piece)
        {
            piece.OnStop -= piece_OnStop;
            if (!GameOver())
                CreateFallingPiece();
        }
    }
