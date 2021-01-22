    public static class UnixDateTime
    {
        public static DateTimeOffset FromUnixTimeSeconds(long seconds)
        {
            if (seconds < -62135596800L || seconds > 253402300799L)
                throw new ArgumentOutOfRangeException("seconds", seconds, "");
            return new DateTimeOffset(seconds * 10000000L + 621355968000000000L, TimeSpan.Zero);
        }
        public static DateTimeOffset FromUnixTimeMilliseconds(long milliseconds)
        {
            if (milliseconds < -62135596800000L || milliseconds > 253402300799999L)
                throw new ArgumentOutOfRangeException("milliseconds", milliseconds, "");
            return new DateTimeOffset(milliseconds * 10000L + 621355968000000000L, TimeSpan.Zero);
        }
        public static long ToUnixTimeSeconds(this DateTimeOffset utcDateTime)
        {
            return utcDateTime.Ticks / 10000000L - 62135596800L;
        }
        public static long ToUnixTimeMilliseconds(this DateTimeOffset utcDateTime)
        {
            return utcDateTime.Ticks / 10000L - 62135596800000L;
        }
        [Test]
        public void UnixSeconds()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTimeOffset utcNowOffset = new DateTimeOffset(utcNow);
            long unixTimestampInSeconds = utcNowOffset.ToUnixTimeSeconds();
            DateTimeOffset utcNowOffsetTest = UnixDateTime.FromUnixTimeSeconds(unixTimestampInSeconds);
            Assert.AreEqual(utcNowOffset.Year, utcNowOffsetTest.Year);
            Assert.AreEqual(utcNowOffset.Month, utcNowOffsetTest.Month);
            Assert.AreEqual(utcNowOffset.Date, utcNowOffsetTest.Date);
            Assert.AreEqual(utcNowOffset.Hour, utcNowOffsetTest.Hour);
            Assert.AreEqual(utcNowOffset.Minute, utcNowOffsetTest.Minute);
            Assert.AreEqual(utcNowOffset.Second, utcNowOffsetTest.Second);
        }
        [Test]
        public void UnixMilliseconds()
        {
            DateTime utcNow = DateTime.UtcNow;
            DateTimeOffset utcNowOffset = new DateTimeOffset(utcNow);
            long unixTimestampInMilliseconds = utcNowOffset.ToUnixTimeMilliseconds();
            DateTimeOffset utcNowOffsetTest = UnixDateTime.FromUnixTimeMilliseconds(unixTimestampInMilliseconds);
            Assert.AreEqual(utcNowOffset.Year, utcNowOffsetTest.Year);
            Assert.AreEqual(utcNowOffset.Month, utcNowOffsetTest.Month);
            Assert.AreEqual(utcNowOffset.Date, utcNowOffsetTest.Date);
            Assert.AreEqual(utcNowOffset.Hour, utcNowOffsetTest.Hour);
            Assert.AreEqual(utcNowOffset.Minute, utcNowOffsetTest.Minute);
            Assert.AreEqual(utcNowOffset.Second, utcNowOffsetTest.Second);
            Assert.AreEqual(utcNowOffset.Millisecond, utcNowOffsetTest.Millisecond);
        }
    }
