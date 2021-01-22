    namespace myProject.Tests.Respository
    {
        class FakeRepository : ISeriesRepository
        {
            private static IQueryable<Series> fakeSeries = new List<Series> {
                new Series { id = 1, name = "Series1", openingDate = new DateTime(2001,1,1) },
                new Series { id = 2, name = "Series2", openingDate = new DateTime(2002,1,30),
                ...
                new Series { id = 10, name = "Series10", openingDate = new DateTime(2001,5,5)
            }.AsQueryable();
    
            public IQueryable<Series> Series
            {
                get { return fakeSeries; }
            }
        }
    }
