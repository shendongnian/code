    // Note: replacing CommitmentItem<T> in your example with ICollection<T>
    // and ITransaction with object.
    var list = new List<ICollection<object>>();
    // If the behavior you wanted were possible, then this should be possible, since:
    // 1. List<string> implements ICollection<string>; and
    // 2. string inherits from object.
    list.Add(new List<string>());
    // Now, since list is typed as List<ICollection<object>>, our innerList variable
    // should be accessible as an ICollection<object>.
    ICollection<object> innerList = list[0];
    // But innerList is REALLY a List<string>, so although this SHOULD be
    // possible based on innerList's supposed type (ICollection<object>),
    // it is NOT legal due to innerList's actual type (List<string>).
    // This would constitute undefined behavior.
    innerList.Add(new object());
