    public class Node<T> where T:IComparable
    {
        public T Value { get; set; }
        
        public IList<Node<T>> Children { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }
        public static Func<T, Node<T>, Node<T>> GetFindFirstFunc()
        {
            Func<T, Node<T>,Node<T>> func = null;
            func = (value,currentNode) =>
                {
                    if (currentNode.Value.CompareTo(value) == 0)
                    {
                        return currentNode;
                    }
                    if (currentNode.Children != null)
                    {
                        foreach (var child in currentNode.Children)
                        {                            
                            var result = func(value, child);
                            if (result != null)
                            {
                                //found the first match, pass that out as the return value as the call stack unwinds
                                return result;
                            }
                        }
                    }
                    return null;
                };
            return func;
        }
        public static Func<T, Node<T>, IEnumerable<Node<T>>> GetFindAllFunc()
        {
            Func<T, Node<T>, IEnumerable<Node<T>>> func = null;
            List<Node<T>> matches = new List<Node<T>>();
            func = (value, currentNode) =>
            {
                //capture the matches  List<Node<T>> in a closure so that we don't re-create it recursively every time.
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    matches.Add(currentNode);
                }
                if (currentNode.Children != null)
                {
                    //process all nodes
                    foreach (var child in currentNode.Children)
                    {
                        func(value, child);
                    }
                }
                return matches;
            };
            return func;
        }       
    }
