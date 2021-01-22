    string str = "abcd";
    Func<int, int> factorial = n => 
        Enumerable.Range(1, n)
        .Aggregate((i, j) => i * j);
    Func<int, int, int[]> tofactoradic = (n, strLength) =>
        Enumerable.Range(1, strLength)
        .Reverse()
        .Select(i => { var m = n; n /= i; return m % i; })
        .ToArray();
    Func<int[], string, string> Apply = (f, s) => {
        var chars = s.ToList();
        var result = "";
        for (int i = 0; i < s.Length; i++) {
            result += chars[f[i]];
            chars.RemoveAt(f[i]);
        }
        return result;
    };
    int max = factorial(str.Length);
    for (int i = 0; i < max; i++ ) {
        var f = tofactoradic(i, str.Length);
        Console.WriteLine(Apply(f, str));
    }
