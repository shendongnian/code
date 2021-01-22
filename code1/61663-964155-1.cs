    internal class TestClassTests 
    {
        internal abstract class BaseContext : ContextSpecification
        {
            protected TestClass _sut;
            protected override void Act()
            {
            }
            protected override void EstablishContext()
            {
                _sut = new TestClass ();
               // common wiring
            }
        }
       internal class Given_this_situation : BaseContext
       {
           protected override void EstablishContext()
           {
               base.EstablishContext();
               // test specific wiring
           }
           protected override void Act()
           {
               // carry out the test actions
           }
           [UnitTest]
           public void ThisShouldBeTrue()
           {
              Assert.IsTrue();
           }
       }
    }
