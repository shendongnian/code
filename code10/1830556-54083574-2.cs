    static bool IsPalindrom(int numb)
    {
        var productString = Convert.ToString(numb);
        var sub1 = productString.Substring(0, productString.Length / 2);
        var sub2 = new string(productString.Substring(productString.Length / 2 + (productString.Length % 2 == 1 ? 1 : 0), productString.Length / 2).Reverse().ToArray());
        Console.WriteLine(sub1);
        Console.WriteLine(sub2);
        return sub1.Equals(sub2);
    }
