    [Serializable]
    public class ListItem<T>
    {
        public T Value { get; set; }
        public string Text { get; set; }
        public object DataContext { get; set; }
        public Nullable<bool> Checked { get; set; }
    
        public ListItem()
        {
            this.Checked = false;
        }
    }
