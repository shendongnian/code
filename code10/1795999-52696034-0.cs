    List<Int64> Listofid = new List<Int64>() { 5, 3, 9, 7, 5, 9, 3, 7 };
    List<Int64> filteredlist = new List<Int64>()  { 8, 3, 6, 4, 4, 9, 1, 0 };
    List<Int64> Except = filteredlist.Except(Listofid).ToList();
    Console.WriteLine("Except Result");
    foreach (int num in Except)
    {
        Console.WriteLine("{0} ", num); //Result =  8,6,4,1,0
    }
 
 
