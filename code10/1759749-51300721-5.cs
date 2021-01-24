    var arr = new int[] { 1, 2, 3 };
    Console.WriteLine("Arr: " + string.Join(",", arr)); //Arr: 1,2,3
    var imm = GetImmutableArray(arr);
    Console.WriteLine("ImmutableArray: " + string.Join(",", imm)); //ImmutableArray: 1,2,3
    arr[0] = 234;
    imm[0] = 235; //Compile Error
    Console.WriteLine("ImmutableArray: " + string.Join(",", imm)); //ImmutableArray: 234,2,3
