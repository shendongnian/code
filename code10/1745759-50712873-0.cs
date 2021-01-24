    public class HoroscopeData
    {
        public string sign;
        public List<string> prediction;
        public HoroscopeData(string sign)
        {
            this.sign = sign;
            this.prediction = GetPredictionForSign(sign);
        }
        private List<string> GetPredictionForSign(string sign)
        {
            List<string> predition = new List<string>();
            for (int i = 0; i < 3; i++)
                predition.Add("Prediction of " + sign + " " + i.ToString());
            return predition;
        }
    }
