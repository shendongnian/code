    public BlockTemplate this[int x,int y, int z]
    {
        get
        {
            try
            {
                return Data.BlockTemplate[World[Center.X + x, Center.Y + y, Center.Z + z]];
            }
            catch(IndexOutOfRangeException e)
            {
                return Data.BlockTemplate[BlockType.Air];
            }
        }
    }
