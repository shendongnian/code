    //construct a new individual with the genes of the parents
    //method used is cross over mapping
    //note that Individual datastrucuture contains an integer array called Genes which            //contains the route.
    //
    public Individual Breed(Individual father, Individual mother)
    {
        int[] genes = new int[father.Genes.Length];
        int[] map = new int[father.Genes.Length + 1]; //create a map to map the indices
        int crossoverPoint1 = rand.Next(1, father.Genes.Length - 2); //select 2 crossoverpoints, without the first and last nodes, cuz they are always thje same
        int crossoverPoint2 = rand.Next(1, father.Genes.Length - 2);
        father.Genes.CopyTo(genes, 0); //give child all genes from the father
        for (int i = 0; i < genes.Length; i++) //create the map
        {
            map[genes[i]] = i;
        }
        //int[] genesToCopy = new int[Math.Abs(crossoverPoint1 - crossoverPoint2)]; //allocate space for the mother genes to copy
        if (crossoverPoint1 > crossoverPoint2) //if point 1 is bigger than point 2 swap them
        {
            int temp = crossoverPoint1;
            crossoverPoint1 = crossoverPoint2;
            crossoverPoint2 = temp;
        }
        //Console.WriteLine("copy mother genes into father genes from {0} to {1}", crossoverPoint1, crossoverPoint2);
        for (int i = crossoverPoint1; i <= crossoverPoint2; i++) //from index one to the 2nd
        {
            int value = mother.Genes[i];
            int t = genes[map[value]]; //swap the genes in the child
            genes[map[value]] = genes[i];
            genes[i] = t;
            t = map[genes[map[value]]]; //swap the indices in the map
            map[genes[map[value]]] = map[genes[i]];
            map[genes[i]] = t;
        }
        Individual child = new Individual(genes);
        return child;
    }
