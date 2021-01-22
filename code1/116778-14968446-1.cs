        [Serializable]
        class TreeNode
        {
            private string word;
            private Dictionary<string, TreeNode> children;
            public string Word
            {
                get { return word; }
                set { word = value; }
            }
            public Dictionary<string, TreeNode> Children
            {
                get { return children; }
                set { children = value; }
            }
        }
