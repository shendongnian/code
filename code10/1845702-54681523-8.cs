    public class Matrix
    {
        ICell[][] cell;
        public Matrix(bool mode, string data)
        {
            cell = (mode)? new CellA(data): new CellB(data);
        }
    }
