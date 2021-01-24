    public class TestA: Test<TestItem>
    {
        protected void IRepositoryRelouder.Reload() => 
            new ConcurentBag<TestItem>(LoadData())
    }
