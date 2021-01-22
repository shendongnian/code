    public static IEnumerable<TElement> UniqueBy<TElement, TKey>
        (this IEnumerable<TElement> source,
         Func<TElement, TKey> keySelector)
    {
        var results = new LinkedList<TElement>();
        // If we've seen a key 0 times, it won't be in here.
        // If we've seen it once, it will be in as a node.
        // If we've seen it more than once, it will be in as null.
        var nodeMap = new Dictionary<TKey, LinkedListNode<TElement>>();
        
        foreach (TElement element in source)
        {
            TKey key = keySelector(element);
            LinkedListNode<TElement> currentNode;
            
            if (nodeMap.TryGetValue(key, out currentNode))
            {
                // Seen it before. Remove if non-null
                if (currentNode != null)
                {
                    results.Remove(currentNode);
                    nodeMap[key] = null;
                }
                // Otherwise no action needed
            }
            else
            {
                LinkedListNode<TElement> node = results.AddLast(element);
                nodeMap[key] = node;
            }
        }
        foreach (TElement element in results)
        {
            yield return element;
        }
    }
