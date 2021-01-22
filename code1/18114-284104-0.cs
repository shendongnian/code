using System;
using System.Collections.Generic;
namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] pattern = new byte[] {12,3,5,76,8,0,6,125};
            byte[] toBeSearched = new byte[] {23,36,43,76,125,56,34,234,12,3,5,76,8,0,6,125,234,56,211,<br>122,22,4,7,89,76,64,12,3,5,76,8,0,6,125};
            List&lt;int&gt; occurences = findOccurences(toBeSearched, pattern);
            foreach(int occurence in occurences) {
                Console.WriteLine("Found match starting at 0-based index: " + occurence);
            }
        }
        static List&lt;int&gt; findOccurences(byte[] haystack, byte[] needle)
        {
            List&lt;int&gt; occurences = new List&lt;int&gt;();
            for (int i = 0; i &lt; haystack.Length; i++)
            {
                if (needle[0] == haystack[i])
                {
                    bool found = true;
                    int j, k;
                    for (j = 0, k = i; j &lt; needle.Length; j++, k++)
                    {
                        if (k &gt;= haystack.Length || needle[j] != haystack[k])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        occurences.Add(i - 1);
                        i = k;
                    }
                }
            }
            return occurences;
        }
    }
}
