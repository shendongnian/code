    List<int> GetFactors(int n)
    {
        var f = new List<int>() { 1 };  // adding trivial factor, optional
        int m = n;
        int i = 2;
        while (m > 1)
        {
            if (m % i == 0)
            {
                f.Add(i);
                m /= i;
            }
            else i++;
        }
        // f.Add(n);   // adding trivial factor, optional
        return f;
    }
