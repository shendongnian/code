    // the generic class which uses the basetype as generic
    public static class DocumentDBRepository<T> where T : BaseType
    {
        public static IEnumerable<T> SelectData(Func<T, bool> predicate)
        {
            // some static test data
            return Data<T>.MyData.Where(predicate);
        }
    }
---
    // your derived class from BaseType
    public class MyLookupThing : BaseType
    {
    }
