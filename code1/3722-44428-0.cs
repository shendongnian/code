    System.Random r = new System.Random();
    
    double rnd( double a, double b )
    {
       return a + r.NextDouble()*(b-a);
    }
