    var dictionarya = lista.ToDictionary
    (
        item => item.id,
        item => item
    );
    foreach (var b in listb)
    {
        A a;
        if (dictionarya.TryGetValue(b.id, out a))
        {
            a.val2 = b.val2;
            a.val4 = b.val3;
        }
    }
