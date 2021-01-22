    public void WalkPath2()
    {
        Queue<Path<DataRow>> queue = new Queue<Path<DataRow>>();
        queue.Enqueue(new Path<DataRow>(this, null));
        while (queue.Count > 0)
        {
            Path<DataRow> currentPath = queue.Dequeue();
            DataRow currentNode = currentPath.Node;
            if (currentNode.children != null)
            {
                foreach (Path<DataRow> nextPath in currentNode.GetChildPermutations(currentPath))
                    queue.Enqueue(nextPath);
            }
            else
            {
                foreach (DataRow node in currentPath.AllNodes())
                {
                    Console.Write(node.ToString());
                    Console.Write("      ");
                }
                Console.WriteLine();
            }
        }
    }
    private IEnumerable<Path<DataRow>> GetChildPermutations(Path<DataRow> currentPath)
    {
        string firstLevelKidType = null;
        foreach (string kidType in children.Keys)
        {
            firstLevelKidType = kidType;
            break;
        }
        foreach (Path<DataRow> pathPermutation in GetNextLevelPermutations(currentPath, firstLevelKidType))
            yield return pathPermutation;
    }
    private IEnumerable<Path<DataRow>> GetNextLevelPermutations(Path<DataRow> currentPath, string thisLevelKidType)
    {
        string nextLevelKidType = null;
        bool nextKidTypeIsTheOne = false;
        foreach (string kidType in children.Keys)
        {
            if (kidType == thisLevelKidType)
                nextKidTypeIsTheOne = true;
            else
            {
                if (nextKidTypeIsTheOne)
                {
                    nextLevelKidType = kidType;
                    break;
                }
            }
        }
        foreach (DataRow node in children[thisLevelKidType])
        {
            Path<DataRow> nextLevelPath = new Path<DataRow>(node, currentPath);
            if (nextLevelKidType != null)
            {
                foreach (Path<DataRow> pathPermutation in GetNextLevelPermutations(nextLevelPath, nextLevelKidType))
                    yield return pathPermutation;
            }
            else
            {
                yield return new Path<DataRow>(node, currentPath);
            }
        }
    }
