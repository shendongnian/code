    public class KeyedObject
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
    public class ObservableMappedCollection : ObservableCollection<KeyedObject>
    {
        private Dictionary<string, KeyedObject> _Map;
        public ObservableMappedCollection(Dictionary<string, KeyedObject> map)
        {
            _Map = map;    
        }
        protected override void InsertItem(int index, KeyedObject item)
        {
            base.InsertItem(index, item);
            _Map[item.Key] = item;
        }
        protected override void RemoveItem(int index)
        {
            KeyedObject item = base[index];
            base.RemoveItem(index);
            _Map.Remove(item.Key);
        }
        protected override void ClearItems()
        {
            base.ClearItems();
            _Map.Clear();
        }
        protected override void SetItem(int index, KeyedObject item)
        {
            KeyedObject oldItem = base[index];
            _Map.Remove(oldItem.Key);
            base.SetItem(index, item);
            _Map[item.Key] = item;
        }
    }
