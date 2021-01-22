    [TestFixture]
    public class EnumerableDataReaderFixture
    {
        private static IEnumerable<DataObj> DataSource
        {
            get
            {
                return new List<DataObj>
                           {
                               new DataObj {Name = "1", Age = 16},
                               new DataObj {Name = "2", Age = 26},
                               new DataObj {Name = "3", Age = 36},
                               new DataObj {Name = "4", Age = 46}
                           };
            }
        }
        [Test]
        public void TestIEnumerableCtor()
        {
            var r = new EnumerableDataReader(DataSource, typeof(DataObj));
            while (r.Read())
            {
                var values = new object[2];
                int count = r.GetValues(values);
                Assert.AreEqual(2, count);
                values = new object[1];
                count = r.GetValues(values);
                Assert.AreEqual(1, count);
                values = new object[3];
                count = r.GetValues(values);
                Assert.AreEqual(2, count);
                Assert.IsInstanceOf(typeof(string), r.GetValue(0));
                Assert.IsInstanceOf(typeof(int), r.GetValue(1));
                Console.WriteLine("Name: {0}, Age: {1}", r.GetValue(0), r.GetValue(1));
            }
        }
        [Test]
        public void TestIEnumerableOfAnonymousType()
        {
            // create generic list
            Func<Type, IList> toGenericList =
                type => (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(new[] { type }));
            // create generic list of anonymous type
            IList listOfAnonymousType = toGenericList(new { Name = "1", Age = 16 }.GetType());
            listOfAnonymousType.Add(new { Name = "1", Age = 16 });
            listOfAnonymousType.Add(new { Name = "2", Age = 26 });
            listOfAnonymousType.Add(new { Name = "3", Age = 36 });
            listOfAnonymousType.Add(new { Name = "4", Age = 46 });
            var r = new EnumerableDataReader(listOfAnonymousType);
            while (r.Read())
            {
                var values = new object[2];
                int count = r.GetValues(values);
                Assert.AreEqual(2, count);
                values = new object[1];
                count = r.GetValues(values);
                Assert.AreEqual(1, count);
                values = new object[3];
                count = r.GetValues(values);
                Assert.AreEqual(2, count);
                Assert.IsInstanceOf(typeof(string), r.GetValue(0));
                Assert.IsInstanceOf(typeof(int), r.GetValue(1));
                Console.WriteLine("Name: {0}, Age: {1}", r.GetValue(0), r.GetValue(1));
            }
        }
        [Test]
        public void TestIEnumerableOfTCtor()
        {
            var r = new EnumerableDataReader(DataSource);
            while (r.Read())
            {
                var values = new object[2];
                int count = r.GetValues(values);
                Assert.AreEqual(2, count);
                values = new object[1];
                count = r.GetValues(values);
                Assert.AreEqual(1, count);
                values = new object[3];
                count = r.GetValues(values);
                Assert.AreEqual(2, count);
                Assert.IsInstanceOf(typeof(string), r.GetValue(0));
                Assert.IsInstanceOf(typeof(int), r.GetValue(1));
                Console.WriteLine("Name: {0}, Age: {1}", r.GetValue(0), r.GetValue(1));
            }
        } 
				// reset of test omitted for brevity
    }
}
-------------------------------------------
    // <copyright project="Salient.Data" file="EnumerableDataReader.cs" company="Sky Sanders">
    // This source is a Public Domain Dedication.
    // Please see http://spikes.codeplex.com/ for details.   
    // Attribution is appreciated
    // </copyright> 
    // <version>1.0</version>
    
    using System;
    using System.Collections;
    
    namespace Salient.Data
    {
        /// <summary>
        /// Creates an IDataReader over an instance of IEnumerable&lt;> or IEnumerable.
        /// Anonymous type arguments are acceptable.
        /// </summary>
        public class EnumerableDataReader : ObjectDataReader
        {
            private readonly IEnumerator _enumerator;
            private readonly Type _type;
            private object _current;
    
            /// <summary>
            /// Create an IDataReader over an instance of IEnumerable&lt;>.
            /// 
            /// Note: anonymous type arguments are acceptable.
            /// 
            /// Use other constructor for IEnumerable.
            /// </summary>
            /// <param name="collection">IEnumerable&lt;>. For IEnumerable use other constructor and specify type.</param>
            public EnumerableDataReader(IEnumerable collection)
            {
                if (collection.GetType().IsGenericType)
                {
                    _type = collection.GetType().GetGenericArguments()[0];
                    SetFields(_type);
                }
                else
                {
                    throw new ArgumentException(
                        "collection must be IEnumerable<>. Use other constructor for IEnumerable and specify type");
                }
    
                _enumerator = collection.GetEnumerator();
            }
    
            /// <summary>
            /// Create an IDataReader over an instance of IEnumerable.
            /// Use other constructor for IEnumerable&lt;>
            /// </summary>
            /// <param name="collection"></param>
            /// <param name="elementType"></param>
            public EnumerableDataReader(IEnumerable collection, Type elementType)
                : base(elementType)
            {
                _type = elementType;
                _enumerator = collection.GetEnumerator();
            }
    
            /// <summary>
            /// Return the value of the specified field.
            /// </summary>
            /// <returns>
            /// The <see cref="T:System.Object"/> which will contain the field value upon return.
            /// </returns>
            /// <param name="i">The index of the field to find. 
            /// </param><exception cref="T:System.IndexOutOfRangeException">The index passed was outside the range of 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. 
            /// </exception><filterpriority>2</filterpriority>
            public override object GetValue(int i)
            {
                if (i < 0 || i >= Fields.Count)
                {
                    throw new IndexOutOfRangeException();
                }
    
                return Fields[i].Getter(_current);
            }
    
            /// <summary>
            /// Advances the <see cref="T:System.Data.IDataReader"/> to the next record.
            /// </summary>
            /// <returns>
            /// true if there are more rows; otherwise, false.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            public override bool Read()
            {
                bool returnValue = _enumerator.MoveNext();
                _current = returnValue ? _enumerator.Current : _type.IsValueType ? Activator.CreateInstance(_type) : null;
                return returnValue;
            }
        }
    }
