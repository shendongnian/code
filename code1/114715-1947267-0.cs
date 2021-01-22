    public class App
    {
        static void Main(string[] eventArgs)
        {
            var list = new[] {10, 20, 30, 40, 50};
            var whatYouNeed = GetWhatYouNeed(list, 60, 60);
            //what you need will contain 50 & 10
           //whatYouNeed = GetWhatYouNeed(list, 105,105);
            //what you need will contain (50,50, 10)
        }
        private static IList<int> _whatYouNeed = new List<int>();
       
        static IEnumerable<int> GetWhatYouNeed(IEnumerable<int> list, int goal, int amountRequired)
        {
            var intYouNeed = list.OrderBy(x => Math.Abs(amountRequired - x)).FirstOrDefault();
            _whatYouNeed.Add(intYouNeed);
            if (_whatYouNeed.Sum() < goal)
            {
                int howMuchMoreDoYouNeed = goal - _whatYouNeed.Sum();
                GetWhatYouNeed(list, goal, howMuchMoreDoYouNeed);
            }
            return _whatYouNeed;
        }
    }
