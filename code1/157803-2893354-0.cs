    public class Program
    {
        class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;
        }
    
        TreeNode constructBalancedTree(List<int> values, int min, int max)
        {
            if (min == max)
                return null;
    
            int median = min + (max - min) / 2;
            return new TreeNode
            {
                Value = values[median],
                Left = constructBalancedTree(values, min, median),
                Right = constructBalancedTree(values, median + 1, max)
            };
        }
    
        TreeNode constructBalancedTree(IEnumerable<int> values)
        {
            return constructBalancedTree(
                values.OrderBy(x => x).ToList(), 0, values.Count());
        }
    
        void Run()
        {
            TreeNode balancedTree = constructBalancedTree(Enumerable.Range(1, 9));
            // displayTree(balancedTree); // TODO: implement this!
        }
    
        static void Main(string[] args)
        {
            new Program().Run();
        }
    }
