    interface IMatrix
    {
        int Rows {get;set;}
        int Columns {get;set;}
        float At(int row, int column);
    }
    
    class ColumnMatrix : IMatrix
    {
        private data[,];
    
        public int Rows {get;set;}
        public int Columns {get;set;}
        public float At(int row, int column)
        {
            return data[row,column];
        }
    }
