        private IEnumerable<T> YieldItems<T>(IEnumerable<T> items, Action empty = null)
        {
            if (items == null)
            {
                if (empty != null) empty();
                yield break;
            }
            foreach (var item in items)
            {
                yield return item;
            }
        }
