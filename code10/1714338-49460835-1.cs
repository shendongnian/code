    public class MyTextBoxColumn:DataGridViewTextBoxColumn
    {
        public MyTextBoxColumn()
        {
            CellTemplate = new MyTextBoxCell();
        }
    }
