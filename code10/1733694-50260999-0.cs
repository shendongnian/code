    class Game
    {
        private Enemy enemy = null; //You have to initialize a field before you can check it, even if you're just checking for null
        public Enemy GetEnemy()
        {
            if (enemy == null)
            {
                enemy = new Enemy();  //Here I am only assigning, not declaring
            }
            return enemy;
        }
    }
