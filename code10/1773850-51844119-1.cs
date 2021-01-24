    bool ComplexCollectionValuesAreEqual(List<ComplexItem1> list1, List<ComplexItem2> list2)
    {
        try
        {
            var grouped = list1.GroupJoin(list2, x => x.Id, x => x.Id, 
                (outer, inners) => outer.Value == inners.Single().Value);
            return grouped.All(x => x);
        }
        catch (InvalidOperationException) // for .Single() fail case
        {
            return false;
        }
    }
