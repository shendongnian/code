    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void MoveLeft() { X++; }
        public void MoveRight() { X--; }
        public void MoveUp() { Y++; }
        public void MoveDown() { Y--; }
        public void MoveFunny() { Y++; X++; }
        public void MoveOtherFunny() { Y--; X--; }
    }
