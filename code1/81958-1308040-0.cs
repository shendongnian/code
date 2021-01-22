    public class BinaryTree<T> where T : IComparable<T>
    {
        public void AddNode(T data)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(data);
            BinaryTreeNode<T> temp = root;
    
            if (temp.Value.CompareTo(node.Value) < 0)
            ...
