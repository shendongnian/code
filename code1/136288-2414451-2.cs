    public abstract class AbstractBinaryTree<TreeType, T>
            where TreeType : AbstractBinaryTree<TreeType, T>
            where T : IComparable<T>
        {
            protected abstract TreeType CreateNode(AbstractBinaryTree<TreeType, T> left, T value, AbstractBinaryTree<TreeType, T> right);
            protected abstract TreeType CreateX(TreeType left, T val, TreeType right);
            protected abstract T Value { get; }
            protected abstract TreeType Left { get; }
            protected abstract TreeType Right { get; }
            protected abstract bool IsNil();
    
            public virtual AbstractBinaryTree<TreeType, T> Insert(T item)
            {
                if (this.IsNil())
                {
                    return CreateNode(this.Left, item, this.Right);
                    // ^ doesn't compile, can't convert type 
                    // AbstractBinaryTree<TreeType, T> to type TreeType 
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
                        return this;
                        // ^ doesn't compile, can't converrt type 
                        // AbstractBinaryTree<TreeType, T> to type TreeType 
                    }
                } 
            }
        }
    
    public class AvlTree<T> : AbstractBinaryTree<AvlTree<T>, T>
        where T : IComparable<T>
    {
        public override AbstractBinaryTree<AvlTree<T>, T> Insert(T item)
        {
            return base.Insert(item);
        }
