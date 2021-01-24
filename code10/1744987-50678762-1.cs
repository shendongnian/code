    public IEnumerable<ElementType> GetSubtreeFlattenedPostOrder()
    {
        return PostOrderRecursive(this);
    
        IEnumerable<ElementType> PostOrderRecursive(BinaryTree<ElementType> currentNode)
        {
            if (currentNode.HasLeft)
            {
                foreach (var node in PostOrderRecursive(currentNode.Left))
                {
                    yield return node;
                }
            }
            if (currentNode.HasRight)
            {
                foreach (var node in PostOrderRecursive(currentNode.Right))
                {
                    yield return node;
                }
            }
    
            yield return currentNode.element;
        }
    }
