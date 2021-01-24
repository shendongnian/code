c#
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace SO_54604467
{
    public class Example
    {
        // This is the actual parsing logic
        Dictionary<string, string> Parse(string msg) =>
            msg.TrimStart('{')
                .TrimEnd('}')
                .Split(',')
                .Select(s => s.Split('='))
                .ToDictionary(
                    key => key[0].Trim(),
                    val => val[1].Trim('"')
                );
        [Fact]
        public void ParseExampleInput()
        {
            // This string was provided in the original question
            string msg = "{Type=\"wednesday report\", corporate=\"ubl\", reg#=\"BNN - 527\", Driven=\"304.5Km\", MaxSpeed=\"150km / hr\", IgnitionsON=\"5\", Stopped=\"21.8hrs\", Running=\"1.7hrs\", Idle=\"0.5hrs\", image=\"varbinary data from db\", link=\"http://iteck.pk/d/pXhAo\"}";
            // This is the data I would expect the message to parse into
            var expected = new Dictionary<string, string>
            {
                ["Type"] = "wednesday report",
                ["corporate"] = "ubl",
                ["reg#"] = "BNN - 527",
                ["Driven"] = "304.5Km",
                ["MaxSpeed"] = "150km / hr",
                ["IgnitionsON"] = "5",
                ["Stopped"] = "21.8hrs",
                ["Running"] = "1.7hrs",
                ["Idle"] = "0.5hrs",
                ["image"] = "varbinary data from db",
                ["link"] = "http://iteck.pk/d/pXhAo",
            };
            var actual = Parse(msg);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void DemonstrateFailureWithBadInput()
        {
            // This string fails, because it contains an unexpected comma
            string msg = "{Type=\"wednesday, report\"}";
            Assert.ThrowsAny<Exception>(() => Parse(msg));
        }
    }
}
