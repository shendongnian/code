    public class Interval
    {
        public int Start {get; set;}
        public int End {get; set;}
        public int Step {get; set;}
        public double Value {get; set;}
        public WriteToDictionary(Dictionary<int, double> dict)
        {
            for(int i = Start; i < End; i += Step)
            {
                dict.Add(i, Value);
            }
        }
    }
