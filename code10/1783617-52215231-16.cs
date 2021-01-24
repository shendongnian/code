    [Test("for", "", false)]
    public BigInteger Test3(string input, int scale)
    {       
       BigInteger result = 0;
       for (int i = 0; i < input.Length; i++)
       {
          result += BigInteger.Pow(95, i) * (input[i] - 32);
       }
       return result;
    }
