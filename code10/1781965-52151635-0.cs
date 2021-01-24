    class BaseTreeData<T> where T : BaseTreeData<T>
    {
        public bool IsChecked { get; set; }
        public T Parent { get; set; }
        public List<T> Children { get; set; }
        public BaseTreeData()
        {
            Children = new List<T>();
        }
    }
    class TreeData : BaseTreeData<TreeData>
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
