    String a = "toto".Substring(0, 4);
    String b = "toto";
    Object aAsObj = a;
    Assert.IsTrue(a.Equals(b));
    Assert.IsTrue(a == b);
    Assert.IsFalse(aAsObj == b);
    Assert.IsTrue(aAsObj.Equals(b));
