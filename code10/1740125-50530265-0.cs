    public class DigitPrediction
    {
        [ColumnName("PredicatedLabel")]
        public uuint ExpectedDigit; // <-- This is the predicted value
        
        [ColumnName("Score")]
        public float[] Score; // <-- This is the probability that the predicted value is the right classification
    }
