    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config(10, 7, 5)
            {
                { new int?[]{null,  null,  null},  1},
                { new int?[]{1,     null,  null},  2},
                { new int?[]{9,     null,  null},  21},
                { new int?[]{1,     null,  3},     3 },
                { new int?[]{null,  2,     3},     4 },
                { new int?[]{1,     2,     3},     5 }
            };
            Console.WriteLine("5 == {0}", config[1, 2, 3]);
            Console.WriteLine("4 == {0}", config[3, 2, 3]);
            Console.WriteLine("1 == {0}", config[8, 10, 11]);
            Console.WriteLine("2 == {0}", config[1, 10, 11]);
            Console.WriteLine("4 == {0}", config[9, 2, 3]);
            Console.WriteLine("21 == {0}", config[9, 3, 3]);            
            Console.ReadKey();
        }
    }
    public class Config : IEnumerable
    {
        private readonly int[] priorities;
        private readonly List<KeyValuePair<int?[], int>> rules =
            new List<KeyValuePair<int?[], int>>();
        private DefaultMapNode rootNode = null;
        public Config(params int[] priorities)
        {
            // In production code, copy the array to prevent tampering
            this.priorities = priorities;
        }
        public int this[params int[] keys]
        {
            get
            {
                if (keys.Length != priorities.Length)
                {
                    throw new ArgumentException("Invalid entry - wrong number of keys");
                }
                if (rootNode == null)
                {
                    rootNode = BuildTree();
                    //rootNode.PrintTree(0);
                }
                DefaultMapNode curNode = rootNode;
                for (int i = 0; i < keys.Length; i++)
                {
                    // if we're at a leaf, then we're done
                    if (curNode.value != null)
                        return (int)curNode.value;
                    if (curNode.children.ContainsKey(keys[i]))
                        curNode = curNode.children[keys[i]];
                    else
                        curNode = curNode.defaultChild;
                }
                return (int)curNode.value;
            }
        }
        private DefaultMapNode BuildTree()
        {
            return new DefaultMapNode(new int?[]{}, rules, priorities);
        }
        public void Add(int?[] keys, int value)
        {
            if (keys.Length != priorities.Length)
            {
                throw new ArgumentException("Invalid entry - wrong number of keys");
            }
            // Again, copy the array in production code
            rules.Add(new KeyValuePair<int?[], int>(keys, value));
            // reset the tree to know to regenerate it.
            rootNode = null;
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }
    public class DefaultMapNode
    {
        public Dictionary<int, DefaultMapNode> children = new Dictionary<int,DefaultMapNode>();
        public DefaultMapNode defaultChild = null; // done this way to workaround dict not handling null
        public int? value = null;
        public DefaultMapNode(IList<int?> usedValues, IEnumerable<KeyValuePair<int?[], int>> pool, int[] priorities)
        {
            int bestScore = Int32.MinValue;
            // get best current score
            foreach (KeyValuePair<int?[], int> rule in pool)
            {
                int currentScore = GetCurrentScore(usedValues, priorities, rule);
                bestScore = Math.Max(bestScore, currentScore);
            }
            // get pruned pool
            List<KeyValuePair<int?[], int>> prunedPool = new List<KeyValuePair<int?[], int>>();
            foreach (KeyValuePair<int?[], int> rule in pool)
            {
                int maxScore = GetCurrentScore(usedValues, priorities, rule);
                if (maxScore == Int32.MinValue)
                    continue;
                for (int i = usedValues.Count; i < rule.Key.Length; i++)
                    if (rule.Key[i] != null)
                        maxScore += priorities[i];
                if (maxScore >= bestScore)
                    prunedPool.Add(rule);
            }
            
            // base optimization case, return leaf node
            // base case, always return same answer
            if ((prunedPool.Count == 1) || (usedValues.Count == prunedPool[0].Key.Length))
            {
                value = prunedPool[0].Value;
                return;
            }
            // add null base case
            AddChild(usedValues, priorities, prunedPool, null);
            foreach (KeyValuePair<int?[], int> rule in pool)
            {
                int? branch = rule.Key[usedValues.Count];
                if (branch != null && !children.ContainsKey((int)branch))
                {
                    AddChild(usedValues, priorities, prunedPool, branch);
                }
            }
            
            // if all children are the same, then make a leaf
            int? maybeOnlyValue = null;
            foreach (int v in GetAllValues())
            {
                if (maybeOnlyValue != null && v != maybeOnlyValue)
                    return;
                maybeOnlyValue = v;
            }
            if (maybeOnlyValue != null)
                value = maybeOnlyValue;
            
        }
        private static int GetCurrentScore(IList<int?> usedValues, int[] priorities, KeyValuePair<int?[], int> rule)
        {
            int currentScore = 0;
            for (int i = 0; i < usedValues.Count; i++)
            {
                if (rule.Key[i] != null)
                {
                    if (rule.Key[i] == usedValues[i])
                        currentScore += priorities[i];
                    else
                        return Int32.MinValue;
                }
            }
            return currentScore;
        }
        private void AddChild(IList<int?> usedValues, int[] priorities, List<KeyValuePair<int?[], int>> prunedPool, Nullable<int> nextValue)
        {
            List<int?> chainedValues = new List<int?>();
            chainedValues.AddRange(usedValues);
            chainedValues.Add(nextValue);            
            DefaultMapNode node = new DefaultMapNode(chainedValues, prunedPool, priorities);
            if (nextValue == null)
                defaultChild = node;
            else
                children[(int)nextValue] = node;
        }
        public IEnumerable<int> GetAllValues()
        {
            foreach (DefaultMapNode child in children.Values)
                foreach (int v in child.GetAllValues())
                    yield return v;
            if (defaultChild != null)
                foreach (int v in defaultChild.GetAllValues())
                    yield return v;
            if (value != null)
                yield return (int)value;
        }
        public void PrintTree(int depth)
        {
            if (value == null)
                Console.WriteLine();
            else
            {
                Console.WriteLine(" = {0}", (int)value);
                return;
            }
            foreach (KeyValuePair<int, DefaultMapNode> child in children)
            {
                for (int i=0; i<depth; i++)
                    Console.Write("    ");
                Console.Write(" {0}  ", child.Key);                
                child.Value.PrintTree(depth + 1);
            }
            for (int i = 0; i < depth; i++)
                Console.Write("    ");
            Console.Write("null");
            defaultChild.PrintTree(depth + 1);
        }
    }
