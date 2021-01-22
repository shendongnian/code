    using System;
    using System.Linq;
    using NUnit.Framework;
    
    namespace Salient.Data.Tests
    {
        [TestFixture]
        public class EnumerableDataReaderEFFixture
        {
            [Test]
            public void TestEnumerableDataReaderWithIQueryableOfAnonymousType()
            {
                var ctx = new NorthwindEntities();
    
                var q =
                    ctx.Orders.Where(o => o.Customers.CustomerID == "VINET").Select(
                        o =>
                        new
                            {
                                o.OrderID,
                                o.OrderDate,
                                o.Customers.CustomerID,
                                Total =
                            o.Order_Details.Sum(
                            od => od.Quantity*((float) od.UnitPrice - ((float) od.UnitPrice*od.Discount)))
                            });
    
                var r = new EnumerableDataReader(q);
                while (r.Read())
                {
                    var values = new object[4];
                    r.GetValues(values);
                    Console.WriteLine("{0} {1} {2} {3}", values);
                }
            }
        }
    }
---------------------------------------------
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using NUnit.Framework;
    
    namespace Salient.Data.Tests
    {
        public class DataObj
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    
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
            // remaining tests omitted for brevity
        }
    }
