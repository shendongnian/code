    int[] arr = { 2, 70, 15, 92, 105, 65, 40, 9, 22 };
    int n = 3;
    var result = arr.OrderByDescending(x=>x).ToArray();
    //Result will contais {105, 92, 70, 65, 40, 22, 15, 9, 2}
    //More readable to newbie 
    for(int i = 0; i < 3; i++)
    {
      Console.Write(result[i]+" ");
    }
