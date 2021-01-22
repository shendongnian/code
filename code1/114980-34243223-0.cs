        /// <summary>
        /// Synches the collection items to the target collection items.
        /// This does not observe sort order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The items.</param>
        /// <param name="updatedCollection">The updated collection.</param>
        public static void SynchCollection<T>(this IList<T> source, IEnumerable<T> updatedCollection)
        {
            // Evaluate
            if (updatedCollection == null) return;
            // Make a list
            var collectionArray = updatedCollection.ToArray();
            // Remove items from FilteredViewItems not in list
            source.RemoveRange(source.Except(collectionArray));
            // Add items not in FilteredViewItems that are in list
            source.AddRange(collectionArray.Except(source));
        }
        /// <summary>
        /// Synches the collection items to the target collection items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="updatedCollection">The updated collection.</param>
        /// <param name="canSort">if set to <c>true</c> [can sort].</param>
        public static void SynchCollection<T>(this ObservableCollection<T> source,
            IList<T> updatedCollection, bool canSort = false)
        {
            // Synch collection
            SynchCollection(source, updatedCollection.AsEnumerable());
            // Sort collection
            if (!canSort) return;
            
            // Update indexes as needed
            for (var i = 0; i < updatedCollection.Count; i++)
            {
                // Index of new location
                var index = source.IndexOf(updatedCollection[i]);
                if (index == i) continue;
                // Move item to new index if it has changed.
                source.Move(index, i);
            }
        }
