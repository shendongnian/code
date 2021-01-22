    public class BinaryTree<T> : IVisitableCollection<T>, ITree<T>
    {
      // Methods
      public void Add(BinaryTree<T> subtree);
      public virtual void breadthFirstTraversal(IVisitor<T> visitor);
      public virtual void 
             DepthFirstTraversal(OrderedVisitor<T> orderedVisitor);
      public BinaryTree<T> GetChild(int index);
      public bool Remove(BinaryTree<T> child);
      public virtual void RemoveLeft();
      public virtual void RemoveRight();
      // ...
      // Properties
      public virtual T Data { get; set; }
      public int Degree { get; }
      public virtual int Height { get; }
      public virtual bool IsLeafNode { get; }
      public BinaryTree<T> this[int i] { get; }
      public virtual BinaryTree<T> Left { get; set; }
      public virtual BinaryTree<T> Right { get; set; }
      
      // ...
    }
