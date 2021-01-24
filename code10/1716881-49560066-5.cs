    class Animal
    {
        // In general, you only need one instance of `Random` per class
        private Random rnd = new Random();
        public int[,] RandomDataGen()
        {
            int[,] Dogs = new int[2, 2];
            int weightIndex = 0;
            int heightIndex = 1;
            //insert numbers to 2D array
            for (int dog = 0; dog < 2; dog++)
            {
                Dogs[weightIndex, dog] = rnd.Next(4, 60);
                Dogs[heightIndex, dog] = rnd.Next(30, 85);
            }
            return Dogs;
        }
    }
