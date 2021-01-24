        public static class OperationalBlockCalculator
        {
            public static string GetOperationalBlock(List<string> workingDays)
            {
                var operationalBlock = new StringBuilder("0000000");
                for (var day = 0; day < 7; day++)
                {
                    if (workingDays.Any(x => x.ElementAt(day).Equals('1')))
                    {
                        operationalBlock[day] = '1';
                    }
                }
                return operationalBlock.ToString();
            }
        }
        [TestFixture]
        public class WhenIMergeTripWorkingDays
        {
            [Test]
            public void ThenItShouldReturnOperationalBlock()
            {
                var workingDays = new List<string> { "0110110", "1000001" };
                OperationalBlockCalculator.GetOperationalBlock(workingDays).Should().Be("1110111");
            }
        }
