    var set = new HashSet<MyCustomClass>();
    var a = new MyCustomClass(1,2);
    var b = new MyCustomClass(1,2);
    set.Add(a);
    set.Add(b);
    Assert.IsTrue(a.Equals(b));
    Assert.IsTrue(b.Equals(a));
    Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
    Assert.AreEqual(1, set.Count);
