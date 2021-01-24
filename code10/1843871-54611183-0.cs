c#
using System;
using Xunit;
namespace Q54610867
{
    public class TimeZoneTests
    {
        // I'm on Mac/Unix. If you're on Windows, change the ID to "Pacific Standard Time"
        readonly TimeZoneInfo pacificStandardTime = TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");
        [Fact]
        public void Today()
        {
            var today = new DateTime(2019, 2, 9, 13, 4, 22, DateTimeKind.Local);
            Assert.Equal("2019-02-09 13:04:22 Pacific Standard Time", ToStringWithTz(today, pacificStandardTime));
        }
        [Fact]
        public void future()
        {
            var future = new DateTime(2019, 4, 9, 13, 4, 22, DateTimeKind.Local);
            Assert.Equal("2019-04-09 13:04:22 Pacific Daylight Time", ToStringWithTz(future, pacificStandardTime));
        }
        static string ToStringWithTz(DateTime dateTime, TimeZoneInfo tz)
            => $"{dateTime.ToString("yyyy-MM-dd HH:mm:ss")} {(tz.IsDaylightSavingTime(dateTime) ? tz.DaylightName : tz.StandardName)}";
    }
}
