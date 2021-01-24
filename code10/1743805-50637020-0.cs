    static void Main(string[] args)
    {
        int num = 10;
        MethodWithoutRef(num);  //adding 2 in number
        Console.WriteLine(num); //still number at caller side not changed
        Method(ref num);        //adding 2 in number (here number is passed by ref) 
        Console.WriteLine(num); //number at caller side changed
        List<int> numList = new List<int>() { 10 };
        //List is default passed by ref, so changes in method will be 
        //      reflected at caller side even without using 'ref' keyword
        MethodWithoutRef(numList);        
        Console.WriteLine(numList[0]);
        numList = new List<int>() { 10 };
        //passing List with 'ref' doesnt make any differece in comparision with
        //      passing it without 'ref'
        Method(ref numList);
        Console.WriteLine(numList[0]);
        Console.ReadLine();
    }
