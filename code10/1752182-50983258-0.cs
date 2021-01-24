    class CharTree {
        public class TreeNode {
            public bool HasChildren { get { return Children.Count > 0; } }
            public Dictionary<char, TreeNode> Children = new Dictionary<char, TreeNode>();
            public TreeNode this[char idx] {
                get { return Children[idx]; }
                set { Children[idx] = value; }
            }
        }
        protected TreeNode Root;
        public void AddChars(string line) {
            if (Root == null) Root = new TreeNode();
            var currentNode = Root;
            foreach(var letter in line) {
                if (!currentNode.Children.ContainsKey(letter))
                    currentNode.Children.Add(letter, new TreeNode());
            }
        }
        public string Validate( string line ) {
            var currentNode = Root;
            if (currentNode == null) return null;
            var result = "";
            foreach ( var letter in line ) {
                currentNode = currentNode[letter];
                if (currentNode == null) break;
                result += letter;
            }
            return result;
        }
    }
