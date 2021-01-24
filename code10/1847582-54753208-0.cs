    //Create an array. Fill it with Sequential Numbers.
    int[] input = new int[20];
    
    for(int i = 0; i < numbers.lenght; i++)
      input[i] = i;
    
    /*Initialise the instances you will need*/
    //Use the array to create a list
    List<int> DrawableNumbers = new List<int>(input);
    List<int> DrawnNumbers = new List<int>();
    
    //Generate a Random Number Generator
    Random rng = new Random();
    
    /*Draw 6 from the group*/
    while(DrawnNumbers.Count < 6){
      //Get a random Index to move from DrawableNumbers to DrawnNumbers
      int temp = Random.NextInt(DrawableNumbers.Count);
      DrawnNumbers.Add(DrawableNumbers[i]);
      DrawableNumbers.Remove(temp);
    }
