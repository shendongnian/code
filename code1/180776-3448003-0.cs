    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    namespace FooLibrary
    {
    public class Foo
    {
        public string Field1 = null;
        public int? Field2 = null;
    }
    public abstract class FieldReader<T>
    {
        public abstract void Fill(T entity, IDataReader reader);
    }
    }
