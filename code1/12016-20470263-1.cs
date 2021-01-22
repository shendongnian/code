    public void test()
    {
        StringBuilder[] sArrOr = new StringBuilder[1];
        sArrOr[0] = new StringBuilder();
        sArrOr[0].Append("hello");
        StringBuilder[] sArrClone = (StringBuilder[])sArrOr.Clone();
        StringBuilder[] sArrCopyTo = new StringBuilder[1];
        sArrOr.CopyTo(sArrCopyTo,0);
        sArrOr[0].Append(" world");
        Console.WriteLine(sArrOr[0] + " " + sArrClone[0] + " " + sArrCopyTo[0]);
        //Outputs: hello world hello world hello world
        //Same result in int[] as using String[]
        int[] iArrOr = new int[2];
        iArrOr[0] = 0;
        iArrOr[1] = 1;
        int[] iArrCopyTo = new int[2];
        iArrOr.CopyTo(iArrCopyTo,0);
        int[] iArrClone = (int[])iArrOr.Clone();
        iArrOr[0]++;
        Console.WriteLine(iArrOr[0] + " " + iArrClone[0] + " " + iArrCopyTo[0]);
       // Output: 1 0 0
    }
