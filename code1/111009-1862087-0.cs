    static unsafe void MyMethod(int* array)
    {
        array[10] = 10;
    }
    static unsafe void Main()
    {
        int[, , ,] array = new int[10, 10, 10, 10];
        fixed (int* ptr = array)
        {
            MyMethod(ptr);
        }
        int x = array[0, 0, 1, 0]; // == 10
    }
