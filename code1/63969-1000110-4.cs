    public class Bar : IFoo
    {
        public IEnumerable<int> GetItems( ref int somethingElse )
        {
            somethingElse = 42;
            return GetItemsCore();
        }
        private IEnumerable<int> GetItemsCore();
        {
            yield return 7;
        }
    }
