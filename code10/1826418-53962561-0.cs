    static void Main(string[] args)
    {
        string code = "({GoldPrice} * 0.376) + {MP.011} + {SilverPrice}";
        // Step 1. Extract "MP.011"
        int pFrom = code.IndexOf("{MP.");
        int pTo = code.IndexOf("}", pFrom+1);
        string part = code.Substring(pFrom+1, pTo-pFrom-1);
        // Step 2. Extact "011"
        String result = part.Substring(3);
    }
