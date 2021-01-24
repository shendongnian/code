    static void Main(string[] args)
    {
        int[,] arr = new int[3, 5];
        int val = 1;
        int total = 0;
        //Both init the array with data, and get the sum of all elements
        for (int c=0; c<3; ++c)
        {
            for(int r=0; r<5; ++r)
            {
                arr[c,r] = val;
                total += val;
                //Console.Write("{0} ", val);
                val <<= 1;
            }
            //Console.WriteLine("");
        }
        //Do the math
        int b = arr.GetLength(0);
        int e = arr.GetLength(1) - 1;
        int power = (int)Math.Pow(b, e);
        total *= power;
        Console.WriteLine(total); //Outputs 2654127
    }
