    public class LimitedListBox : ListBox
    {
        private int _maxItems = 100;
    
        public LimitedListBox()
        {
            SetItems(new LimitedObjectCollection(this, _maxItems));
        }
    
        public int MaxItems
        {
            get { return _maxItems; }
            set { _maxItems = value; }
        }
    
        /// <summary>
        /// This is the only 'bug' - no design time support for Items unless
        /// you create an editor.
        /// </summary>
        public new LimitedObjectCollection Items
        {
            get
            {
                if (base.Items == null)
                {
                    SetItems(new LimitedObjectCollection(this, _maxItems));
                }
                return (LimitedObjectCollection) base.Items;
            }
        }
    
        private void SetItems(ObjectCollection items)
        {
            FieldInfo info = typeof (ListBox).GetField("itemsCollection",
                                                       BindingFlags.NonPublic | BindingFlags.Instance |
                                                       BindingFlags.GetField);
            info.SetValue(this, items);
        }
    
        #region Nested type: LimitedObjectCollection
    
        public class LimitedObjectCollection : ObjectCollection
        {
            private int _maxItems;
    
            public LimitedObjectCollection(ListBox owner, int maxItems)
                : base(owner)
            {
                _maxItems = maxItems;
            }
    
            public LimitedObjectCollection(ListBox owner, ObjectCollection value, int maxItems)
                : base(owner)
            {
                _maxItems = maxItems;
                AddRange(value);
            }
    
            public LimitedObjectCollection(ListBox owner, object[] value, int maxItems)
                : base(owner)
            {
                _maxItems = maxItems;
                AddRange(value);
            }
    
            public int MaxItems
            {
                get { return _maxItems; }
                set { _maxItems = value; }
            }
    
            public new int Add(object item)
            {
                if (base.Count >= _maxItems)
                {
                    return -1;
                }
    
                return base.Add(item);
            }
    
            public new void AddRange(object[] items)
            {
                int allowed = _maxItems - Count;
                if (allowed < 1)
                {
                    return;
                }
    
                int length = allowed <= items.Length ? allowed : items.Length;
                var toAdd = new object[length];
                Array.Copy(items, 0, toAdd, 0, length);
    
                base.AddRange(toAdd);
            }
    
            public new void AddRange(ObjectCollection value)
            {
                var items = new object[value.Count];
                value.CopyTo(items, 0);
    
                base.AddRange(items);
            }
        }
    
        #endregion
    }
