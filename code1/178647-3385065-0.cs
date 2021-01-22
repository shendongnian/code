    public class BoardEngineTest {
        @Test
        public void engineShouldSetCellsBlack() {
            // 1. create mock
            IBoard mockBoard = EasyMock.createMock(IBoard.class);
            // 2. program mock
            EasyMock.reset(mockBoard); // put in record mode
            // this doesn't actually happen now, the mock is just
            // being programmed to expect this method call with this
            // argument
            mockBoard.setAllCellsTo(Color.Black);
            // 3. put in replay mode - it's alive at this point!
            EasyMock.replay(mockBoard);
            
            // do something that cause the mock to be used
            BoardEngine engine = new BoardEngine(mockBoard);
            // 4. make sure cells were actually set to black!
            EasyMock.verify(mockBoard);
        }
    }
