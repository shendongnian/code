    public class LinkedList
    {
        public string UniqueKey { get; set; }
        public LinkedList LinkedList { get; set; }
    
        public IEnumerable<LinkedList> GetAllNodes()
        {
            if (LinkedList != null)
            {
                yield return LinkedList;
                foreach (var node in LinkedList.GetAllNodes())
                    yield return node;
            }
        }
    }
