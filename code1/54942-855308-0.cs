    // if BorrowReader is generic...
    public delegate T BorrowReader<T>(IDataReader reader);
    public class Foo
    {
        // ... and Foo.Bar() is also generic
        public static T Bar<T>(BorrowReader<T> borrower) { ... }
        public void SomeMethod()
        {
            // this does *not* work (compiler needs more help)
            var result1 = Foo.Bar(DoFooBarMagic);
            // but instead of this (which works)
            var result2 = Foo.Bar(new BorrowReader<List<string>>(DoFooBarMagic));
            // you can do this (also works)
            // which emits the same IL, anyway
            var result3 = Foo.Bar<List<string>>(DoFooBarMagic);
        }
    }
