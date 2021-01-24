    public class Block
    {
        private List<Rectangle> _block;
        public List<Rectangle> block
        {
            get { return _block; }
        }
    
        private int _blockNum;
        public int blockNum
        {
            get { return _blockNum; }
        }
        // Copy constructor
        public Block(Block originalBlock)
        {
            this._block = originalBlock.block;
            this._blockNum = originalBlock.blockNum;
        }
    }
