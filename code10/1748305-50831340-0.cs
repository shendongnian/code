     public class Bot
    {
        public int row = 0;
        public int col = 0;
        public void startRoutine()
        {
            if (row != 3 && col != 3)
            {
                if (Globals.map[row, col + 1] == 0)
                {
                    // Simply update the data, no need to create a new class
                    this.Move(row, col + 1);
                }
                if (Globals.map[row + 1, col] == 0)
                {
                    // Simply update the data, no need to create a new class
                    this.Move(row + 1, col);
                }
            }
            if (row == 3 && col == 3)
            {
                Globals.count++;
            }
        }
        private void Move(int x, int y)
        {
            row = x;
            col = y;
            startRoutine();
        }
        public Bot(int x, int y)
        {
            row = x;
            col = y;
            startRoutine();
        }
    }
