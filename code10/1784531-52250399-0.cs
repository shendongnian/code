    static Random rnd = new Random((int)DateTime.Now.Ticks);
    static int[] GetRandomArray(int arrSize, int minNumber, int maxNumber)
    {
        int[] tmpArr = new int[maxNumber - minNumber + 1];
        for (int i = 0; i < tmpArr.Length; ++i)
        {
            tmpArr[i] = i + minNumber; // fill with 1, 2, 3, 4,...
        }
        int[] ret = new int[arrSize];
        for (int i = 0; i < ret.Length; ++i)
        {
            int index = rnd.Next(tmpArr.Length - i); //choose random position
            ret[i] = tmpArr[index];
            tmpArr[index] = tmpArr[tmpArr.Length - 1 - i]; //fill last of the sequence into used position
        }
        return ret;
    }
    static IEnumerable<int> GetMatches(int[] a, int[] b)
    {
        Array.Sort(a);
        Array.Sort(b);
        for (int i = 0, j = 0; i < a.Length && j < b.Length;)
        {
            if (a[i] == b[j])
            {
                yield return a[i];
                ++i;
                ++j;
            }
            else if (a[i] > b[j])
            {
                ++j;
            }
            else
            {
                ++i;
            }
        }
    }
    static void Main(string[] args)
    {
        var a = GetRandomArray(5, 3, 7);
        var b = GetRandomArray(10, 1, 25);
        Console.WriteLine("A: " + string.Join(", ", a));
        Console.WriteLine("B: " + string.Join(", ", b));
        Console.WriteLine("Matches: " + string.Join(", ", GetMatches(a, b)));
        Console.ReadKey();
    }
