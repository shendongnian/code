    public partial class HierarchicalNode<TItem, THierarchicalNode>
    {
        public THierarchicalNode GetOrAddChild(string namespaceName)
        {
            THierarchicalNode child;
            if (!Children.TryGetValue(namespaceName, out child))
                child = Children[namespaceName] = new THierarchicalNode();
            return child;
        }
        public void AddObject(IList<string> nodeNames, TItem item)
        {
            AddObject(nodeNames, 0, item);
        }
        void AddObject(IList<string> nodeNames, int index, TItem item)
        {
            if (index >= nodeNames.Count)
                Items.Add(item);
            else
            {
                GetOrAddChild(nodeNames[index]).AddObject(nodeNames, index + 1, item);
            }
        }
    }
