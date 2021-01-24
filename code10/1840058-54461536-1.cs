    IEnumerable<AlignedPartners> olds = ...
    IEnumerable<AlignedPartners> news = ...
    var joinResult = olds.FullOuterJoin(news, // join old and new
        oldItem => oldItem.Id,                // from every old take the Id
        newItem => newItem.Id,                // from every new take the Id
        (key, oldItem, newItem) => new        // when they match make one new object
        {                                     // containing the following properties
             OldItem = oldItem,
             NewItem = newItem,
        });
