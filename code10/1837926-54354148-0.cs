    class powerup
    {
        public static int cooldown = 1;
    }
    
    class freeze : powerup
    {
        public new static int cooldown = 3;
        //some unrelated code
    }
    class burn : powerup
    {
        public new static int cooldown = 2;
        //unrelated
    }
