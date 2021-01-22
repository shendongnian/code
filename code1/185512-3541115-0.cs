    class DateTime {
        public Date getDate() {
            return System.DateTime.Now();
        }
    }
    
    class MockDateTime {
        public Date getDate() {
            return this.fakeDate;
        }
    }
    
    class StopwatchTest {
        public void GoneInSixtySeconds() {
            MockDateTime d = new MockDateTime();
            d.fakeDate = '2010-01-01 12:00:00';
            Stopwatch s = new Stopwatch();
            s.Run();
            d.fakeDate = '2010-01-01 12:01:00';
            s.Stop();
            assertEquals(60, s.ElapsedSeconds);
        }
    }
