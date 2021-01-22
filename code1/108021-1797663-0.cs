    public abstract class Base {}
    public class D1 : Base {}
    public class D2 : Base {}
    
    [Test]
    public void Test_Generic_Lists_With_Abstract_Base()
    {
        var list = new List<Base>();
        list.Add(new D1());
        list.Add(new D2());
    
        Assert.That(list[0] is D1);
        Assert.That(list[1] is D2);
    }
