private static int NumberReplacingCompare(string strA, string strB)
{
    return ReplaceDigits(strA).CompareTo(ReplaceDigits(strB));
}
private static void OutputSortedStrings()
{
    List<string> strings = new List<string>(File.ReadAllLines(@"D:\Working\MyStrings.txt")); //pull the strings from a file (or wherever they come from
    strings.Sort(NumberReplacingCompare); //sort, using NumberReplacingCompare as the comparison function
    foreach (string s in strings)
    {
        System.Console.WriteLine(s);
    }
}
