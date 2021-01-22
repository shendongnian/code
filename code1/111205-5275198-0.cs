    public class RaceConditionSample
    {
        private static int number = 0;
        public static int Addition()
        {
            int x = RaceConditionSample.number;
            x = x + 1;
            RaceConditionSample.number = x;
            return RaceConditionSample.number;
        }
        public int Set()
        {
            RaceConditionSample.number = 42;
            return RaceConditionSample.number;
        }
        public int Reset()
        {
            RaceConditionSample.number = 0;
            return RaceConditionSample.number;
        }
    }
    RaceConditionSample sample = new RaceConditionSample();
    System.Diagostics.Debug.WriteLine(sample.Set());
    // Consider the following two lines are called in different threads in any order, Waht will be the
    // output in either order and/or with any "interweaving" of the individual instructions...?
    System.Diagostics.Debug.WriteLine(RaceConditionSample.Addition());
    System.Diagostics.Debug.WriteLine(sample.Reset());
