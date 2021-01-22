    public interface IDiceRoller
    {
        int GetValue(int lowerBound, int upperBound);
    }
    
    public class DefaultRoller : IDiceRoller
    {
        public int GetValue(int lowerBound, int upperBound)
        {
            // return random value between lowerBound and upperBound
        }
    }
    
    public class Dice
    {
        private static IDiceRoller _diceRoller = new DefaultRoller();
    
        public static void SetDiceRoller(IDiceRoller diceRoller)
        {
            _diceRoller = diceRoller;
        }
    
        public static void Roll(int lowerBound, int upperBound)
        {
            int newValue = _diceRoller.GetValue(lowerBound, upperBound);
            // use newValue
        }
    }
