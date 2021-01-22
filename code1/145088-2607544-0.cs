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
    [Serializable]
    public class ListItemCollection<T> : List<ListItem<T>>
    {
        public ListItem<T> this[T value]
        {
            get
            {
                foreach (var child in this)
                {
                    if (object.Equals(child.Value, value))
                        return child;
                }
                return null;
            }
        }
        public bool Contains(T value)
        {
            foreach (var child in this)
            {
                if (object.Equals(child.Value, value))
                    return true;
            }
            return false;
        }
        public void Add(T value, string text)
        {
            this.Add(value, text, null);
        }
        public void Add(T value, string text, object dataContext)
        {
            var child = new ListItem<T>();
            child.Value = value;
            child.Text = text;
            child.DataContext = dataContext;
            this.Add(child);
        }
        public ListItemCollection()
        {
        }
        public ListItemCollection(IEnumerable items,
            string displayMember,
            string valueMember,
            bool showEmptyItem,
            string emptyItemText,
            T emptyItemValue)
        {
            if (showEmptyItem)
            {
                this.Add(emptyItemValue, emptyItemText);
            }
            foreach (object item in items)
            {
                object text = null;
                T value = default(T);
                text = item.GetType().GetProperty(displayMember).GetValue(item, null);
                value = (T)item.GetType().GetProperty(valueMember).GetValue(item, null);
                // Add the item
                this.Add(value, text.ToString(), item);
            }
        }
    }
