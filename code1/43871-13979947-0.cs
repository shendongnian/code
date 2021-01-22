     static void Main()
        {
            // Create a string array 2 elements in length:
            int arrayLength = 2;
            Array dynamicArray = Array.CreateInstance(typeof(int), arrayLength);
            dynamicArray.SetValue(234, 0);                              //  → a[0] = 234;
            dynamicArray.SetValue(444, 1);                              //  → a[1] = 444;
            int number = (int)dynamicArray.GetValue(0);                      //  → number = a[0];
    
    
            int[] cSharpArray = (int[])dynamicArray;
            int s2 = cSharpArray[0];
    
        }
