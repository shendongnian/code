    Assert.IsTrue(IsSimple(typeof(string));
    Assert.IsTrue(IsSimple(typeof(int));
    Assert.IsTrue(IsSimple(typeof(decimal));
    Assert.IsTrue(IsSimple(typeof(float));
    Assert.IsTrue(IsSimple(typeof(StringComparison));  // enum
    Assert.IsTrue(IsSimple(typeof(int?));
    Assert.IsTrue(IsSimple(typeof(decimal?));
    Assert.IsTrue(IsSimple(typeof(StringComparison?));
    Assert.IsFalse(IsSimple(typeof(object));
    Assert.IsFalse(IsSimple(typeof(Point));  // struct
    Assert.IsFalse(IsSimple(typeof(Point?));
    Assert.IsFalse(IsSimple(typeof(StringBuilder)); // reference type
