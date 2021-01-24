     public class RootNode
     {
         private readonly List<SubNode> _subList = new List<SubNode>();
         public ERootType RootType { get; set; }
         public IEnumerable<SubNode> Subs => _subList;
     
         public RootNode(ERootType rootType)
         {
             RootType = rootType;
         }
     
         public void AddSub(SubNode subNodeToAdd)
         {
             _subList.Add(subNodeToAdd);
         }
     }
     
    public class SubNode
    {
        private readonly List<ItemNode> _itemList = new List<ItemNode>();
        public ESubType SubType { get; set; }
        public IEnumerable<ItemNode> Items => _itemList;
    
        public SubNode(ESubType subType)
        {
            SubType = subType;
        }
    
        public void AddItem(ItemNode itemToAdd)
        {
            _itemList.Add(itemToAdd);
        }
    }
    
    public class ItemNode
    {
        private readonly List<Payload> _payloadList  = new List<Payload>();
    
        public string Item { get; set; }
        public IEnumerable<Payload> Payloads => _payloadList;
        public ItemNode(string item)
        {
            Item = item;
        }
    
        public void AddPayload(Payload payloadToAdd)
        {
            _payloadList.Add(payloadToAdd);
        }
    }
