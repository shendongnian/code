    string indexStr1 = Console.ReadLine();
    string indexStr2 = Console.ReadLine();
    int index1 = getIndex(indexStr1);
    int index2 = getIndex(indexStr2);
    if(index1 == -1 || index2 == -1) {
        Console.WriteLine("Invalid index provided");
        return;
    }
    
    int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
    Console.WriteLine(array[index1, index2]);
