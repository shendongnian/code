        public bool Remove(T item)
        {
            var index = list.BinarySearch(item);
            if (index < 0) return false;
            while (((IComparable)item).CompareTo((IComparable)list[index]) == 0)
            {
                if (item == list[index])
                {
                    list.RemoveAt(index);
                    return true;
                }
                index++;
            }
            return false;
        }
