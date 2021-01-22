    public class MainBoard {
        private IBoardType1 bt1;
        private IBoardType2 bt2;
        private IBoardType3 bt3;
        ...
        private Size boardSize;
        public MainBoard(IBoardBuilderFactory factory) {
            this.bt1 = factory.buildBoard(boardSize);
            //...
        }
    }
