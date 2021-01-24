        using System.Collections.Generic;
    
    public interface ITreeNode
    {
        string ParentId { get; set; }
        string Id { get; set; }
        dbItem item { get; set; }
        List<ITreeNode> Nodes { get; set; }
    }
    
    public class TreeNode : ITreeNode
    {
        public TreeNode()
        { }
    
        public string ParentId { get; set; }
        public string Id { get; set; }
        public dbItem item { get; set; }
        public List<ITreeNode> Nodes { get; set; }
    }
    
    public class dbItem
    {
        public string ParentId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    class app
    {
         
    
        static void Main()
        {
            List<dbItem> dbSet = new List<dbItem>();
    
            dbSet.Add(new dbItem() { Id = "5", ParentId = "1", Name = "Jan" });
            dbSet.Add(new dbItem() { Id = "25", ParentId = "1", Name = "Maria" });
            dbSet.Add(new dbItem() { Id = "1", Name = "John" });
            dbSet.Add(new dbItem() { Id = "8", ParentId = "2", Name = "Cornelis" });
            dbSet.Add(new dbItem() { Id = "2", Name = "Ilse" });
            dbSet.Add(new dbItem() { Id = "3", Name = "Nick" });
            dbSet.Add(new dbItem() { Id = "87", ParentId = "5", Name = "Rianne" });
            dbSet.Add(new dbItem() { Id = "67", ParentId = "3000", Name = "Rianne" });
            dbSet.Add(new dbItem() { Id = "3000", Name = "Max" });
    
            List<TreeNode> result = BuildTree<TreeNode>(dbSet);
    
        }
    
        private class ParentComparer<T> : IComparer<ITreeNode> where T: ITreeNode
        {
            public int Compare(ITreeNode x, ITreeNode y)
            {
                if (x.ParentId == null) return -1; //have the parents first
                return x.ParentId.CompareTo(y.ParentId);
            }
        }
        private class IdComparer<T> : IComparer<ITreeNode> where T : ITreeNode
        {
            public int Compare(ITreeNode x, ITreeNode y)
            {
               return x.Id.CompareTo(y.Id);
            }
        }
    
        static private List<T> BuildTree<T> (List<dbItem> table) where T: ITreeNode, new()
        {
            //temporary list of tree nodes to build the tree
            List<T> tmpNotAssignedNodes = new List<T>();
            List<T> tmpIdNodes = new List<T>();
            List<T> roots = new List<T>();
    
            IComparer<T> pc = (IComparer<T>) new ParentComparer<T>();
            IComparer<T> ic = (IComparer<T>) new IdComparer<T>();
    
            foreach (dbItem item in table)
            {
                T newNode = new T() { Id = item.Id, ParentId = item.ParentId, item = item };
                newNode.Nodes = new List<ITreeNode>();
                T dummySearchNode = new T() { Id = item.ParentId, ParentId = item.ParentId };
    
                if (string.IsNullOrEmpty(item.ParentId))
                    roots.Add(newNode);
                else
                {
                    int parentIndex = tmpIdNodes.BinarySearch(dummySearchNode, ic);//Get the parent
                    if (parentIndex >=0)
                    {
                        T parent = tmpIdNodes[parentIndex];
                        parent.Nodes.Add(newNode);
                    }
                    else
                    {
                        parentIndex = tmpNotAssignedNodes.BinarySearch(dummySearchNode, pc);
                        if (parentIndex < 0) parentIndex = ~parentIndex;
                        tmpNotAssignedNodes.Insert(parentIndex, newNode);
                    }
                }
    
                dummySearchNode.ParentId = newNode.Id;
    
                //Cleanup Unassigned
                int unAssignedChildIndex = tmpNotAssignedNodes.BinarySearch(dummySearchNode, pc);
    
                while (unAssignedChildIndex >= 0 && unAssignedChildIndex < tmpNotAssignedNodes.Count)
                {
                    if (dummySearchNode.ParentId == tmpNotAssignedNodes[unAssignedChildIndex].ParentId)
                    {
                        T child = tmpNotAssignedNodes[unAssignedChildIndex];
                        newNode.Nodes.Add(child);
                        tmpNotAssignedNodes.RemoveAt(unAssignedChildIndex);
                    }
                    else unAssignedChildIndex--;
                }
                int index = tmpIdNodes.BinarySearch(newNode, ic);
                tmpIdNodes.Insert(~index, newNode);
                
            }
    
    
            return roots;
        }
    }
