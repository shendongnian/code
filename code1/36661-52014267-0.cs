    public static List <int []> ListOfPairs (int [] items)
    {
        List <int> output = new List <int>();
        for (int i=0; i < items.Length-1; i++)
        {
            Int [] pair = new int [2];
            pair [0]=items [i];
            pair [1]=items [i+1];
            output.Add (pair);
        }
        return output;
    }
