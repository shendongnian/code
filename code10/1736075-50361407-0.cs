     public class DependencyTree<TTreeLeaf, TTreeLeafNode>
            : LinkedList<TTreeLeaf>
            where TTreeLeaf : DependencyTreeLeaf
            where TTreeLeafNode : DependencyTreeLeafNode
        {
    
            public DependencyTree(ICollection<TTreeLeaf> leaves)
            {
                foreach (var leaf in leaves)
                {
                    AddLast(new LinkedListNode<TTreeLeaf>(leaf));
                }                 
    
                var y = this.Nodes().Count(node => node.Next != null || node.Previous != null);
                Console.WriteLine(y.ToString());
            }
    
            public IEnumerable<LinkedListNode<TTreeLeaf>> Nodes()
            {
                var node = this.First;
                while (node != null)
                {
                    yield return node;
                    node = node.Next;
                }
            }
        }
