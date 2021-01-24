    unsafe public static void SomeMethod(int* p, int size)
    {
       for (var i = 0; i < 4; i++)
       {
          //Perform any linear operation
          *(p + i) *= 10;
       }
    }
    ...
    var someArray = new int[2,2];
    someArray[0, 0] = 1;
    someArray[0,1] = 2;
    someArray[1, 0] = 3;
    someArray[1, 1] = 4;
    
    //Reshape an array to a linear array 
    fixed (int* p = someArray)
    {
         SomeMethod(p, 4);
    }
    //Reshape result array to original rank and dimensions.
    for (int i = 0; i < 2; i++)
    {
       for (int j = 0; j < 2; j++)
       {
          Console.WriteLine(someArray[i, j]);
       }
    }
