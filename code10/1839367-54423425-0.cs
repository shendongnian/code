	[TestClass]
	public class A 
	{
	  [TestMethod]
	  public virtual void Test1(){....}
	}
	[TestClass]
	public class B : A
	{
	  [TestMethod]
	  public override void Test1()
      {
        base.Test1();
      }
	  [TestMethod]
	  public void Test2(){....}
	}
