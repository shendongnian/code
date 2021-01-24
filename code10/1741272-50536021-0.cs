    #string[] path = File.ReadLines("C:\\Users\\M\\numb.txt").ToArray();    
    String[] path = {"1","2","3"};
    int[] numb = Array.ConvertAll(path,int.Parse);
    for (int i = 0; i < path.Length; i++)
    {
        Console.WriteLine(path[i]);
    }
    for (int i = 0; i < numb.Length; i++)
    {
        Console.WriteLine(numb[i]);
    }
