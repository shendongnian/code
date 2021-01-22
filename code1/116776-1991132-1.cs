    class TreeNode
    {
        protected byte[] word;
        protected Dictionary&lt;byte[], TreeNode&gt; children;
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
[Edit]
And I forgot that you also need a new comparer for the byte[] key.
    var children = new Dictonary<string,TreeNode>(new ByteArrayComparer);
    public class ByteArrayComparer : IEqualityComparer<byte[]>
	{
		public bool Equals(byte[] x, byte[] y)
		{
			if (x.Length != y.Length)
				return false;
			for (int i = 0; i < x.Length; i++)
			{
				if (x[i] != y[i])
					return false;
			}
			return true;
		}
		public int GetHashCode(byte[] a)
		{
			return a[0] | (int)a[1] << 8 | (int)a[2] << 16 | (int)a[3] << 24;
		}
	}
