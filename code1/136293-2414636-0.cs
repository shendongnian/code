    public abstract class AbstractBinaryTree<TreeType, T>
        where TreeType : AbstractBinaryTree<TreeType, T>
        where T : IComparable<T>
    {
        protected abstract TreeType CreateNil();
        protected abstract TreeType CreateNode(TreeType left, T value, TreeType right);
        
        protected abstract T Value { get; }
        protected abstract TreeType Left { get; }
        protected abstract TreeType Right { get; }
        protected abstract bool IsNil();
        public virtual TreeType Insert(T item)
        {
            if (this.IsNil())
            {
                // can't return 'this', so just creating a new nil node
                TreeType nil = CreateNil();
                return CreateNode(nil, item, nil);
            }
            else
            {
                int compare = item.CompareTo(this.Value);
                if (compare < 0)
                {
                    return CreateNode(this.Left.Insert(item), this.Value, this.Right);
                }
                else if (compare > 0)
                {
                    return CreateNode(this.Left, this.Value, this.Right.Insert(Value));
                }
                else
                {
                    // can't return 'this', so just creating a new node with a
                    // copy of the same values
                    return CreateNode(this.Left, this.Value, this.Right);
                }
            }
        }
    }
    public class AvlTree<T> : AbstractBinaryTree<AvlTree<T>, T>
    {
        public override AvlTree<T> Insert(T value) { return Balance(base.Insert(value)); }
    }
