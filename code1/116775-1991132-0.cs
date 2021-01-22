    class TreeNode
    {
        protected byte[] word;
        protected Dictionary<byte[], TreeNode> children;
        public string Word
        {
            get { return Encoding.UTF8.GetString(word); }
            set { word = Encoding.UTF8.GetBytes(value); }
        }
        public TreeNode GetChildByKey( string key )
        {
            TreeNode node;
            if(children.TryGetValue( Encoding.UTF8.GetBytes(key), out node  ))
            {
                return node;
            }
            return null;
        }
    }</code></pre>
