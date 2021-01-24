    public class GridColumnAttribute : System.Attribute
    {
        public GridColumnAttribute(int index)
        {
            this.Index = index;
        }
        public int Index { get; set; }
    }
