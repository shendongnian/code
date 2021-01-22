    class BaseSortedCollection<T> : Collection<T>, ICollection<T>, IEnumerable<T>,
        System.Collections.ICollection, System.Collections.IEnumerable
        where T : IComparable<T>
    {
        /// <summary>
        ///     Adds an item to the Collection<T> at the correct position.
        /// </summary>
        /// <param name="item">The object to add to </param>
        public void Add(T item)
        {
            int pos = GetInsertPositio(item);
            base.InsertItem(pos, item);
        }
        /// <summary>
        /// Get position where item should be inserted.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Get position where item should be inserted.</returns>
        internal int GetInsertPositio(T item)
        {
            if (item == null)
                throw new ArgumentNullException();
            for (int pos = this.Count - 1; pos >= 0; pos--)
            {
                if (item.CompareTo(this.Items[pos]) < 0)
                    return pos;
            }
            return 0;
        }
    }
