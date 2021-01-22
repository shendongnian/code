    static class ListExtensions
    {
        static void MoveItemAtIndexToFront<T>(this List<T> list, int index)
        {
            T item = list[index];
            list.RemoveAt(index);
            list.Insert(0, item);
        }
    }
