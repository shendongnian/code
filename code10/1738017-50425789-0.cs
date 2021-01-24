    int higher = 43;
    int lower = 21;
    int[] numbers = new int[21]; 
    int index = 0;
    for (int i = lower + 1; i < higher; i++) // if you want to store everything 
                                             // between 21 and 43, you need to 
                                             // start with 22, thus lower + 1
    {
        numbers[index] = i;
        index++;
    }
    for (int c = 0; c < 21; c++)
    {
        Console.WriteLine(numbers[c]);
    }
    Console.ReadLine();
