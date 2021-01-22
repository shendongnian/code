    public static bool ListListsAreEqual<T>(List<List<T>> listlist1, List<List<T>> listlist2)
    {
        if (listlist1.Count != listlist2.Count)
            return false;
    
        var listList2Clone = listlist2.ToList();
    
        foreach (var list1 in listlist1)
        {
            var indexOfMatchInList2 = listlist2Clone
                       .FindIndex(list2 => ListsArePermutations(list1, list2));
    
            if (indexOfMatchInList2 == -1)
                return false;
    
            listList2Clone.RemoveAt(indexOfMatchInList2);
        }
    
        return true;
    }
    
    private static bool ListsArePermutations<T>(List<T> list1, List<T> list2)
    {
        return list1.Count == list2.Count && new HashSet<T>(list1).SetEquals(list2);
    }
