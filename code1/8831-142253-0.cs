    public class Record
    {
        public enum ColumnNames { ID = 0, Name, Date, Int, NumCols };
        
        private IColumn [] columns;
        
        public Record()
        {
            columns = new IColumn[ColumnNames.NumCols];
            columns[ID] = ...
        }
        
        public bool HasChanges
        {
            get
            {
                bool has = false;
                for (int i = 0; i < columns.Length; i++)
                    has |= columns[i].HasChanges;
                return has;
            }
        }
        public void AcceptChanges()
        {
            for (int i = 0; i < columns.Length; i++)
                columns[i].AcceptChanges();
        }
    }
