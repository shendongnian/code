    class Node
    {
        public string Name{get;set;}
        public List<Node> Children{get;set;}
        // this is the magic method!
        public Node Search(Func<Node, bool> predicate)
        {
             // if node is a leaf
             if(this.Children == null || this.Children.Count==0)
             {
                 if (predicate(this))
                    return this;
                 else
                    return null;
             }
             else // Otherwise if node is not a leaf
             {
                 var results = Children.Select(i => i.Search(predicate)).Where(i => i != null).ToList();
                 if (results.Any()){
                    var result = (Node)MemberwiseClone();
                    result.Items = results;
                    return result;
                 }
                 return null;
             }             
        }
    }
