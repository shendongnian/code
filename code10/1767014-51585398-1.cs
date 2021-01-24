    List<int> nums = new List<int>();
    int countTarget = 1000;
    for (int i = 1; i < countTarget; i++)
    {
        //Checks if number is divisible by 5
        if (i % 5 == 0)
        {
            //Writes i to list
            nums.Add(i);
        }
    }
    Console.WriteLine(String.Join("; ", nums.ToArray()));
