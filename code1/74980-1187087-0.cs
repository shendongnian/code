    public class Die
    {
        private int maxValue;
        private int numberOfRolls;
        private Random random;
        
        public Die(int maxValue, int numberOfRolls)
        {
            this.maxValue = maxValue;
            this.numberOfRolls = numberOfRolls;
            this.random = new Random();
        }
        public string Roll()
        {
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < this.numberOfRolls; i++)
            {
                resultString.AppendFormat("Roll #{0} - Result: {1}" + Environment.NewLine, i + 1, this.random.Next(1, maxValue + 1));
            }
            return resultString.ToString();
        } 
    }
