    public static class Extensions
    {
        public static void RemoveAllBefore<T>(this LinkedListNode<T> node)
        {
            while (node.Previous != null) node.List.Remove(node.Previous);
        }
        public static void RemoveAllAfter<T>(this LinkedListNode<T> node)
        {
            while (node.Next != null) node.List.Remove(node.Previous);
        }
    }
