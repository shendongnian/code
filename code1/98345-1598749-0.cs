    public class Player
    {
        protected void Part1() { /* ... */ };
        protected void Part2() { /* ... */ };
    }
    public class HumanPlayer : Player
    {
        public void GetMove()
        {
            Part1();
            GetMouseClick();
            Part2();
        }
    }
    public class BotPlayer : Player
    {
        public void GetMove()
        {
            Part1();
            Part2();
        }
    }
