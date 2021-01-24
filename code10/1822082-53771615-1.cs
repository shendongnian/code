    class NiceRandom
    {
       static Random rand = new Random();
       int count = 0;
       int prevChoice = -1;
       public int Next()
       {
           int r = rand.Next(0,2);
           if (r == prevChoice)
           {
               count++;
               // switch our "random" result if there are 3 of the same rolls
               r = count < 3 ? r : (r == 0 ? 1 : 0);
           }
           if (r != prevChoice)
           {
               // reset count if we roll other value.
               prevChoice = r;
               count = 0;
           }
           return r;
       }
    }
