	var board = MockRepository.GenerateStub<IBoard>();
	board.Size = new Size(2,2);
	BoardEngine boardEngine = new BoardEngine(board);
	board.AssertWasCalled(b => b.SetAllCellsTo(Color.Black),
		 options => options.Repeat.Times(1));
