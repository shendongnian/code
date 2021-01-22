    public class ChessPiece
    {
      public ChessPiece() { /*[...]*/ }
      public Coord Location { get; }
      //a measure of how good it would be to move this piece
      public int GoodnessOfBestMove
      {
        get
        {
          //calculate what self's best possible move is
          ... todo ...
        }
      }
      //an instruction to go head and do that move
      public void Move()
      {
        //do self's self-calculated best move, by updating self's private Location
        ... todo ...
      }
    }
    
    class Strategy
    {
        void Move()
        {
          ChessPiece bestChessPiece = null;
          foreach (ChessPiece chessPiece in chestPieces)
          {
            if ((bestChessPiece == null) ||
              (chessPiece.GoodnessOfBestMove > bestChessPiece.GoodnessOfBestMove))
            {
              //found a better piece to move
              bestChessPiece = chessPiece;
            }
          }
          //found the best piece to move, so now tell it to move itself
          bestChessPiece.Move();
        }
    }
