        public class Node<T>
        {
            public T Data;
            public Node<T> Left;
            public Node<T> Right;
            public static void ForEach(Node<T> root, Action<T> action)
            {
                action(root.Data);
                if (root.Left != null)
                    ForEach(root.Left, action);
                if (root.Right != null)
                    ForEach(root.Right, action);
            }
        }
        public interface IHasSize
        {
            long Size { get; }
        }
        public static long SumSize<T>(Node<T> root) where T : IHasSize
        {
            long sum = 0;
            Node<T>.ForEach(root, delegate(T item)
            {
                sum += item.Size;
            });
            return sum;
        }
