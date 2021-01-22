    using System;
    using Xunit;
    namespace ambientcontext
    {
        public class TestDateTimeProvider
        {
            [Fact]
            public void TestDateTime()
            {
                var actual = DateTimeProvider.Current.Today;
                var expected = DateTime.Today;
                Assert.Equal<DateTime>(expected, actual);
                using (new MyDateTimeProvider(new DateTime(2012,12,21)))
                {
                    Assert.Equal(2012, DateTimeProvider.Current.Today.Year);
                    using (new MyDateTimeProvider(new DateTime(1984,4,4)))
                    {
                        Assert.Equal(1984, DateTimeProvider.Current.Today.Year);    
                    }
                    Assert.Equal(2012, DateTimeProvider.Current.Today.Year);
                }
                // Fall-Back to Default DateTimeProvider 
                Assert.Equal<int>(expected.Year,  DateTimeProvider.Current.Today.Year);
            }
            private class MyDateTimeProvider : DateTimeProvider 
            {
                private readonly DateTime dateTime; 
                public MyDateTimeProvider(DateTime dateTime):base()
                {
                    this.dateTime = dateTime; 
                }
                public override DateTime Today => this.dateTime.Date;
                
                public override DateTime Now => this.dateTime;
            }
        }
    }
