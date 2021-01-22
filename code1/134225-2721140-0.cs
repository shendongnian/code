    // simple list of numbers
    List<int> numbers = new List<int>(new[] { 1, 2, 3, 4, 5 });
    // wrap it in a binding list
    BindingList<int> sourceList = new BindingList<int>(numbers);
    // project each item to a squared item
    BindingList<int> squaredList = new ProjectedBindingList<int, int>
        (sourceList, i => i*i);
    // whenever the source list is changed, target list will change
    sourceList.Add(6);
    Debug.Assert(squaredList[5] == 36);
