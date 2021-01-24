    public static Double[,] Generate_random()
    {
        Random rnd = new Random();
        Double[,] X = new Double[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                X[i, j] = rnd.Next(0, 10);
            }
        }
        return X;
    }
