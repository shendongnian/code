    Board board = mock(Board.class);
    BoardEngine boardEngine = new BoardEngine(board);
    Tetris tetris = new Tetris(boardEngine);
    when(board.GetColorAt(0, 0)).thenReturn(Color.RED);
    Assert.AreEqual(Color.Red, tetris.GetColorAt(0, 0));
