    public static BigInteger BitArrayToBigDecimal(int[] bitIntArr) {
        // BigInteger can be found in the System.Numerics dll
        BigInteger res = 0;
    
        // I'm totally skipping error handling here
        foreach(int i in bitIntArr) {
            res <<= 1;
            res += i == 1 ? 1 : 0;
        }
        return res;
    }
