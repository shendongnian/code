    public class Asset
    {
        public Asset Child { get; set; }
        public List<Asset> GetChildren()
        {
            return GetChildrenInternal(new List<Asset>(), this);
        }
        private List<Asset> GetChildrenInternal(List<Asset> children, Asset parent)
        {
            if (parent.Child?.Child != null)
            {
                children.Add(parent.Child);
                GetChildrenInternal(children, parent.Child);
            }
            return children;
        }
    }
