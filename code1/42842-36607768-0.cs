    public class RangeCollection<T> : ObservableCollection<T>
    {
        #region Members
        /// <summary>
        /// Occurs when a single item is added.
        /// </summary>
        public event EventHandler<ItemAddedEventArgs<T>> ItemAdded;
        /// <summary>
        /// Occurs when a single item is inserted.
        /// </summary>
        public event EventHandler<ItemInsertedEventArgs<T>> ItemInserted;
        /// <summary>
        /// Occurs when a single item is removed.
        /// </summary>
        public event EventHandler<ItemRemovedEventArgs<T>> ItemRemoved;
        /// <summary>
        /// Occurs when a single item is replaced.
        /// </summary>
        public event EventHandler<ItemReplacedEventArgs<T>> ItemReplaced;
        /// <summary>
        /// Occurs when items are added to this.
        /// </summary>
        public event EventHandler<ItemsAddedEventArgs<T>> ItemsAdded;
        /// <summary>
        /// Occurs when items are removed from this.
        /// </summary>
        public event EventHandler<ItemsRemovedEventArgs<T>> ItemsRemoved;
        /// <summary>
        /// Occurs when items are replaced within this.
        /// </summary>
        public event EventHandler<ItemsReplacedEventArgs<T>> ItemsReplaced;
        /// <summary>
        /// Occurs when entire collection is cleared.
        /// </summary>
        public event EventHandler<ItemsClearedEventArgs<T>> ItemsCleared;
        /// <summary>
        /// Occurs when entire collection is replaced.
        /// </summary>
        public event EventHandler<CollectionReplacedEventArgs<T>> CollectionReplaced;
        #endregion
        #region Helper Methods
        /// <summary>
        /// Throws exception if any of the specified objects are null.
        /// </summary>
        private void Check(params T[] Items)
        {
            foreach (T Item in Items)
            {
                if (Item == null)
                {
                    throw new ArgumentNullException("Item cannot be null.");
                }
            }
        }
        private void Check(IEnumerable<T> Items)
        {
            if (Items == null) throw new ArgumentNullException("Items cannot be null.");
        }
        private void Check(IEnumerable<IEnumerable<T>> Items)
        {
            if (Items == null) throw new ArgumentNullException("Items cannot be null.");
        }
        private void RaiseChanged(NotifyCollectionChangedAction Action)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        #endregion
        #region Bulk Methods
        /// <summary> 
        /// Adds the elements of the specified collection to the end of this.
        /// </summary> 
        public void AddRange(IEnumerable<T> NewItems)
        {
            this.Check(NewItems);
            foreach (var i in NewItems) this.Items.Add(i);
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            this.OnItemsAdded(new ItemsAddedEventArgs<T>(NewItems));
        }
        /// <summary>
        /// Adds variable IEnumerable<T> to this.
        /// </summary>
        /// <param name="List"></param>
        public void AddRange(params IEnumerable<T>[] NewItems)
        {
            this.Check(NewItems);
            foreach (IEnumerable<T> Items in NewItems) foreach (T Item in Items) this.Items.Add(Item);
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            //TO-DO: Raise OnItemsAdded with combined IEnumerable<T>.
        }
        /// <summary> 
        /// Removes the first occurence of each item in the specified collection. 
        /// </summary> 
        public void Remove(IEnumerable<T> OldItems)
        {
            this.Check(OldItems);
            foreach (var i in OldItems) Items.Remove(i);
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            OnItemsRemoved(new ItemsRemovedEventArgs<T>(OldItems));
        }
        /// <summary>
        /// Removes all occurences of each item in the specified collection.
        /// </summary>
        /// <param name="itemsToRemove"></param>
        public void RemoveAll(IEnumerable<T> OldItems)
        {
            this.Check(OldItems);
            var set = new HashSet<T>(OldItems);
            var list = this as List<T>;
            int i = 0;
            while (i < this.Count) if (set.Contains(this[i])) this.RemoveAt(i); else i++;
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            OnItemsRemoved(new ItemsRemovedEventArgs<T>(OldItems));
        }
        /// <summary> 
        /// Replaces all occurences of a single item with specified item.
        /// </summary> 
        public void ReplaceAll(T Old, T New)
        {
            this.Check(Old, New);
            this.Replace(Old, New, false);
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            this.OnItemReplaced(new ItemReplacedEventArgs<T>(Old, New));
        }
        /// <summary> 
        /// Clears this and adds specified collection. 
        /// </summary> 
        public void ReplaceCollection(IEnumerable<T> NewItems, bool SupressEvent = false)
        {
            this.Check(NewItems);
            IEnumerable<T> OldItems = new List<T>(this.Items);
            this.Items.Clear();
            foreach (T Item in NewItems) this.Items.Add(Item);
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            this.OnReplaced(new CollectionReplacedEventArgs<T>(OldItems, NewItems));
        }
        private void Replace(T Old, T New, bool BreakFirst)
        {
            List<T> Cloned = new List<T>(this.Items);
            int i = 0;
            foreach (T Item in Cloned)
            {
                if (Item.Equals(Old))
                {
                    this.Items.Remove(Item);
                    this.Items.Insert(i, New);
                    if (BreakFirst) break;
                }
                i++;
            }
        }
        /// <summary> 
        /// Replaces the first occurence of a single item with specified item.
        /// </summary> 
        public void Replace(T Old, T New)
        {
            this.Check(Old, New);
            this.Replace(Old, New, true);
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            this.OnItemReplaced(new ItemReplacedEventArgs<T>(Old, New));
        }
        #endregion
        #region  New Methods
        /// <summary>
        /// Removes a single item.
        /// </summary>
        /// <param name="Item"></param>
        public new void Remove(T Item)
        {
            this.Check(Item);
            base.Remove(Item);
            OnItemRemoved(new ItemRemovedEventArgs<T>(Item));
        }
        /// <summary>
        /// Removes a single item at specified index.
        /// </summary>
        /// <param name="i"></param>
        public new void RemoveAt(int i)
        {
            T OldItem = this.Items[i]; //This will throw first if null
            base.RemoveAt(i);
            OnItemRemoved(new ItemRemovedEventArgs<T>(OldItem));
        }
        /// <summary>
        /// Clears this.
        /// </summary>
        public new void Clear()
        {
            IEnumerable<T> OldItems = new List<T>(this.Items);
            this.Items.Clear();
            this.RaiseChanged(NotifyCollectionChangedAction.Reset);
            this.OnCleared(new ItemsClearedEventArgs<T>(OldItems));
        }
        /// <summary>
        /// Adds a single item to end of this.
        /// </summary>
        /// <param name="t"></param>
        public new void Add(T Item)
        {
            this.Check(Item);
            base.Add(Item);
            this.OnItemAdded(new ItemAddedEventArgs<T>(Item));
        }
        /// <summary>
        /// Inserts a single item at specified index.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="t"></param>
        public new void Insert(int i, T Item)
        {
            this.Check(Item);
            base.Insert(i, Item);
            this.OnItemInserted(new ItemInsertedEventArgs<T>(Item, i));
        }
        /// <summary>
        /// Returns list of T.ToString().
        /// </summary>
        /// <returns></returns>
        public new IEnumerable<string> ToString()
        {
            foreach (T Item in this) yield return Item.ToString();
        }
        #endregion
        #region Event Methods
        private void OnItemAdded(ItemAddedEventArgs<T> i)
        {
            if (this.ItemAdded != null) this.ItemAdded(this, new ItemAddedEventArgs<T>(i.NewItem));
        }
        private void OnItemInserted(ItemInsertedEventArgs<T> i)
        {
            if (this.ItemInserted != null) this.ItemInserted(this, new ItemInsertedEventArgs<T>(i.NewItem, i.Index));
        }
        private void OnItemRemoved(ItemRemovedEventArgs<T> i)
        {
            if (this.ItemRemoved != null) this.ItemRemoved(this, new ItemRemovedEventArgs<T>(i.OldItem));
        }
        private void OnItemReplaced(ItemReplacedEventArgs<T> i)
        {
            if (this.ItemReplaced != null) this.ItemReplaced(this, new ItemReplacedEventArgs<T>(i.OldItem, i.NewItem));
        }
        private void OnItemsAdded(ItemsAddedEventArgs<T> i)
        {
            if (this.ItemsAdded != null) this.ItemsAdded(this, new ItemsAddedEventArgs<T>(i.NewItems));
        }
        private void OnItemsRemoved(ItemsRemovedEventArgs<T> i)
        {
            if (this.ItemsRemoved != null) this.ItemsRemoved(this, new ItemsRemovedEventArgs<T>(i.OldItems));
        }
        private void OnItemsReplaced(ItemsReplacedEventArgs<T> i)
        {
            if (this.ItemsReplaced != null) this.ItemsReplaced(this, new ItemsReplacedEventArgs<T>(i.OldItems, i.NewItems));
        }
        private void OnCleared(ItemsClearedEventArgs<T> i)
        {
            if (this.ItemsCleared != null) this.ItemsCleared(this, new ItemsClearedEventArgs<T>(i.OldItems));
        }
        private void OnReplaced(CollectionReplacedEventArgs<T> i)
        {
            if (this.CollectionReplaced != null) this.CollectionReplaced(this, new CollectionReplacedEventArgs<T>(i.OldItems, i.NewItems));
        }
        #endregion
        #region RangeCollection
        /// <summary> 
        /// Initializes a new instance. 
        /// </summary> 
        public RangeCollection() : base() { }
        /// <summary> 
        /// Initializes a new instance from specified enumerable. 
        /// </summary> 
        public RangeCollection(IEnumerable<T> Collection) : base(Collection) { }
        /// <summary> 
        /// Initializes a new instance from specified list.
        /// </summary> 
        public RangeCollection(List<T> List) : base(List) { }
        /// <summary>
        /// Initializes a new instance with variable T.
        /// </summary>
        public RangeCollection(params T[] Items) : base()
        {
            this.AddRange(Items);
        }
        /// <summary>
        /// Initializes a new instance with variable enumerable.
        /// </summary>
        public RangeCollection(params IEnumerable<T>[] Items) : base()
        {
            this.AddRange(Items);
        }
        #endregion
    }
