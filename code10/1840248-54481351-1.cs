    // somewhere in your code set the board up
    _chessBoard.Rows.Add(new [] {
        new ChessPiece(ChessPieces.Rook, ChessColor.Black),
        new ChessPiece(ChessPieces.Knight, ChessColor.Black),
        // ... etc.
        })
    _chessBoard.Rows.Add(new [] { /* next row ... */ });
    // ... etc.
    
    // to create your output, put this into the override of ToString:
    var output = ""; // should be StringBuilder, but for clarity and since this isn't likely performance limiting...
    var rowIndex = 0;
    foreach (var row in _chessBoard.Rows)
    {
        rowIndex++;
        var blankSpaces = 0;
        foreach(var piece in row)
        {
            if (piece == null) 
            {
                blankSpaces++;
            }
            else
            {
                output += blankSpaces == 0 
                    ? piece.FenId
                    : string.Format("{0}{1}", blankspaces, piece.FenId);
                blankSpaces = 0;
            }
            if (blankSpaces > 0)
            {
                output += blankSpaces;
            }
        }
    
        if (rowIndex != 8)
        {
            output += "/";
        }
    }
