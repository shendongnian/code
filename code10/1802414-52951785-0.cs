    foreach (var item in CTest.GenerateEnumerableTest().Where(i => i.Amount > 6))
    {
        item.Amount = item.Amount * 2;
    }
    foreach (var t in CTest.GenerateEnumerableTest())
    {
       // now you don't expect them to be changed, do you?
    }
