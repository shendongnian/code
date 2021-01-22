    int test = 2458217;
    // returns 0, 3, 5, 6, 9, 15, 16, 18, 21
    //   2^0 + 2^3 + 2^5 + 2^6 + 2^9 +  2^15 +  2^16 +   2^18 +    2^21
    // =   1 +   8 +  32 +  64 + 512 + 32768 + 65536 + 262144 + 2097152
    // = 2458217
    var exponents = GetExponents(test);
    // ...
    public static List<int> GetExponents(int source)
    {
        List<int> result = new List<int>(32);
        for (int i = 0; i < 32; i++)
        {
            if (((source >> i) & 1) == 1)
            {
                result.Add(i);
            }
        }
        return result;
    }
