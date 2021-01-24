    //No need to return anything. The population mutation will be seen by the caller.
    //Additionally, the Roullette wheel was never used.
    public void Mutation(IEnumerable<int[,]> population)
    {
        Random rnd = new Random();
        foreach(int[,] chromosome in population)
        {
            double selectionFactor = rnd.Next(0, 11) / 100.0D; // generate a random number between 0 and 10 and divide result by 100
            //Pm could be passed to the method as an argument
            if (selectionFactor <= Pm) /* check if we will do Crossover */
            {
                int crossoverRow = rnd.Next(0, chromosome.GetLength(0)); 
                int columns = chromosome.GetLength(1);
                for(int c = 0; c < columns; c++)
                {
                    if (chromosome[crossoverRow, c] == 0)
                    {
                        chromosome[crossoverRow, c]  = 1;
                    }
                }
            }
        }
    }
