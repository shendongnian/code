    public class DictionaryNode 
    {
        public Dictionary<string, ListNode> Dictionary { get; } = new Dictionary<string, ListNode>();
        public ListNode this[string name]
        {
            get
            {
                return Dictionary[name];
            }
        }
    }
    public class ListNode 
    {
        public List<DictionaryNode> List { get; } = new List<DictionaryNode>();
        public DictionaryNode this[int index]
        {
            get
            {
                return List[index];
            }
        }
        //to make writing [0] optional
        public ListNode this[string name]
        {
            get
            {
                return List[0][name];
            }
        }
    }
