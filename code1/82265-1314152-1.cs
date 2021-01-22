    static void GetNumber(int num, int max) {
        Console.WriteLine(GetNumber(num, max, ""));
    }
    static int GetNumber(int num, int max, string prefix) {
        if (num < 2) {
            Console.WriteLine(prefix + max);
            return 1;
        }
        else {
            int count = 0;
            for (int i = max; i >= 0; i--)
                count += GetNumber(num - 1, max - i, prefix + i + " ");
            return count;
        }
    }
