    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
    [TestFixture]
    public class ForEachTests
    {
        public void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
        private string _extensionOutput;
        private void SaveExtensionOutput(string value)
        {
            _extensionOutput += value;
        }
        private string _instanceOutput;
        private void SaveInstanceOutput(string value)
        {
            _instanceOutput += value;
        }
        [Test]
        public void Test1()
        {
            string[] teams = new string[] {"cowboys", "falcons", "browns", "chargers", "rams", "seahawks", "lions", "heat", "blackhawks", "penguins", "pirates"};
            Each(teams, SaveInstanceOutput);
            teams.Each(SaveExtensionOutput);
            Assert.AreEqual(_extensionOutput, _instanceOutput);
        }
    }
