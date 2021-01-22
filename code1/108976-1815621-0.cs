    public static IEnumerable<T> <T,TCollection> GetNodesRecursively(this TCollection nodeCollection, Func<T, TCollection> getSub)
     where T, TCollection: IEnumerable
    {   
        foreach (var theNode in )
        {
            yield return theNode;
            foreach (var subNode in GetNodesRecursively(theNode, getSub))
            {
                yield return subNode;
            }
        }
    }
    var all_control = GetNodesRecursively(control, c=>c.Controls).ToList();
