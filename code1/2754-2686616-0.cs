    using System;
    using DevExpress.Xpo;
    using DevExpress.Data.Filtering;
    using NUnit.Framework;
    
    namespace XpoTdd {
        public class Person:XPObject {
            public Person(Session session) : base(session) { }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            [Persistent]
            public string FullName { get { return FirstName + " " + LastName; } }
        }
        [TestFixture]
        public class PersonTests {
            [Test]
            public void TestPersistence() {
                const string connStr = "Integrated Security=SSPI;Pooling=false;Data Source=(local);Initial Catalog=XpoTddTest";
                UnitOfWork session1 = new UnitOfWork();
                session1.ConnectionString = connStr;
                Person me = new Person(session1);
                me.FirstName = "Roman";
                me.LastName = "Eremin";
                session1.CommitChanges();
                UnitOfWork session2 = new UnitOfWork();
                session2.ConnectionString = connStr;
                me = session2.FindObject<Person>(CriteriaOperator.Parse("FullName = 'Roman Eremin'"));
                Assert.AreEqual("Roman Eremin", me.FullName);
            }
        }
    }
