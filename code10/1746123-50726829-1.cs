    [TestFixture]
    public class SyntaxTest
    {
        public class Record
        {
            public string Id;
            public DateTime? StartDate;
            public DateTime? EndDate;
            public string isActiveinDB;
        }
        [TestCase]
        public void TestConditionalSyntax()
        {
            var list = new List<Record>
            {
                new Record { Id = "0000", StartDate = DateTime.Parse("2018-01-01"), EndDate = DateTime.Parse("2018-06-01"), isActiveinDB = "Y" },
                new Record { Id = "0001", StartDate = DateTime.Parse("2018-01-01"), EndDate = DateTime.Parse("2018-09-01"), isActiveinDB = "N" },
                new Record { Id = "0002", StartDate = DateTime.Parse("2018-01-01"), EndDate = DateTime.Parse("2018-08-01"), isActiveinDB = "Y" },
                new Record { Id = "0003", StartDate = DateTime.Parse("2018-01-01"), EndDate = null, isActiveinDB = "Y" },
                new Record { Id = "0004", StartDate = DateTime.Parse("2018-08-01"), EndDate = null, isActiveinDB = "Y" },
                new Record { Id = "0005", StartDate = null, EndDate = DateTime.Parse("2018-06-01"), isActiveinDB = "Y" },
                new Record { Id = "0006", StartDate = null, EndDate = DateTime.Parse("2018-08-01"), isActiveinDB = "Y" },
            };
            var date = DateTime.Parse("2018-06-15");
            var result1 = list.Where(x => ( x.StartDate.HasValue ? x.StartDate <= date : true )
                                     && ( x.EndDate.HasValue ? x.EndDate >= date : true )
                                     && x.isActiveinDB.Equals("Y")).ToList();
            Assert.That(result1.Count, Is.EqualTo(3));
            var result2 = list.Where(x => x.StartDate.HasValue ? x.StartDate <= date : true
                                     && x.EndDate.HasValue ? x.EndDate >= date : true
                                     && x.isActiveinDB.Equals("Y")).ToList();
            Assert.That(result2.Count, Is.EqualTo(3));
        }
    }
