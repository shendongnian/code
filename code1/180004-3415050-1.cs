    public class BoardAssembler {
       public static MainBoard assembleBoard(Size size) {
          Size innerBoardSize = deriveSizeOfInternalBoards(size);
          return new MainBoard(new BoardType1(innerBoardSize), new BoardType2(innerBoardSize), new BoardType3(innerBoardSize));
       }
    }
