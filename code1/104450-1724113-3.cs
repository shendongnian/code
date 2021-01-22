    public interface I {}
    public class A {}
    public class B : A, I {}
    public class C : B {}
    
    [Test]
    public void ClosestAncestorTest()
    {
        Type closestAncestor = ClosestAncestor<I,C>();
        Assert.AreEqual(typeof(B), closestAncestor);
    }
