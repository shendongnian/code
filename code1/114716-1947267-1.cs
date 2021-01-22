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
        {   //this will make sure 20 is taken over 10, if the goal is 15. highest wins
            var intYouNeed = list.OrderBy(x => Math.Abs(amountRequired - x)).FirstOrDefault(x => x > amountRequired);
            if (intYouNeed == 0) intYouNeed = list.OrderBy(x => Math.Abs(amountRequired - x)).FirstOrDefault();
            _whatYouNeed.Add(intYouNeed);
            if (_whatYouNeed.Sum() < goal)
            {
                int howMuchMoreDoYouNeed = goal - _whatYouNeed.Sum();
                GetWhatYouNeed(list, goal, howMuchMoreDoYouNeed);
            }
            return _whatYouNeed;
        }
    }
