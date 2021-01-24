    class Demo
    {
        delegate int MyDelegate(ref int[] _scores, int _aScore);
        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int[] result = new int[alice.Count()];
            var distinctScores = scores.Distinct().ToArray();
            MyDelegate locateRanking = (ref int[] scoresArr, int aliceScore) => {
                var itr = Array.Find(scoresArr, el => el <= aliceScore);
                var idx = Array.FindIndex(scoresArr, score => score == itr);
                return idx == -1 ? distinctScores.Count() + 1 : idx + 1;
            };
            for (int i = 0; i < alice.Count(); i++)
            {
                result[i] = locateRanking(ref distinctScores, alice[i]);
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] scores = { 100, 90, 90, 80, 75, 60 };
            int[] alice = { 50, 65, 77, 90, 102 };
            int[] result = new int[alice.Count()];
            result = climbingLeaderboard(scores, alice);
        }
    }
