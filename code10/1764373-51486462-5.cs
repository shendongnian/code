    public class TestA: Test<TestItem, ConcurentBag<TestItem>>
    {
       public TestA() : base(x => new ConcurentBag<TestItem>(x))
       {  
       }
    }
