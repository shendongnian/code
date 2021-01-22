    namespace TestLibrary
    {
        public class TakesRefNullableInt
        {
            public void Foo(ref Nullable<int> ni)
            {
                ni = null;
            }
        }
    }
