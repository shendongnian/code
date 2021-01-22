    using System.Collections.Generic;
    
    namespace KMPSearch
    {
        public class KMPSearch
        {
            public static int NORESULT = -1;
    
            private string _needle;
            private string _haystack;
            private int[] _jumpTable;
    
            public KMPSearch(string haystack, string needle)
            {
                Haystack = haystack;
                Needle = needle;
            }
    
            public void ComputeJumpTable()
            {
                //Fix if we are looking for just one character...
                if (Needle.Length == 1)
                {
                    JumpTable = new int[1] { -1 };
                }
                else
                {
                    int needleLength = Needle.Length;
                    int i = 2;
                    int k = 0;
    
                    JumpTable = new int[needleLength];
                    JumpTable[0] = -1;
                    JumpTable[1] = 0;
    
                    while (i <= needleLength)
                    {
                        if (i == needleLength)
                        {
                            JumpTable[needleLength - 1] = k;
                        }
                        else if (Needle[k] == Needle[i])
                        {
                            k++;
                            JumpTable[i] = k;
                        }
                        else if (k > 0)
                        {
                            JumpTable[i - 1] = k;
                            k = 0;
                        }
    
                        i++;
                    }
                }
            }
    
            public int[] MatchAll()
            {
                List<int> matches = new List<int>();
                int offset = 0;
                int needleLength = Needle.Length;
                int m = Match(offset);
    
                while (m != NORESULT)
                {
                    matches.Add(m);
                    offset = m + needleLength;
                    m = Match(offset);
                }
    
                return matches.ToArray();
            }
    
            public int Match()
            {
                return Match(0);
            }
    
            public int Match(int offset)
            {
                ComputeJumpTable();
    
                int haystackLength = Haystack.Length;
                int needleLength = Needle.Length;
    
                if ((offset >= haystackLength) || (needleLength > ( haystackLength - offset))) 
                    return NORESULT;
    
                int haystackIndex = offset;
                int needleIndex = 0;
    
                while (haystackIndex < haystackLength)
                {
                    if (needleIndex >= needleLength)
                        return haystackIndex;
    
                    if (haystackIndex + needleIndex >= haystackLength)
                        return NORESULT;
    
                    if (Haystack[haystackIndex + needleIndex] == Needle[needleIndex])
                    {
                        needleIndex++;
                    } 
                        else
                    {
                        //Naive solution
                        haystackIndex += needleIndex;
    
                        //Go back
                        if (needleIndex > 1)
                        {
                            //Index of the last matching character is needleIndex - 1!
                            haystackIndex -= JumpTable[needleIndex - 1];
                            needleIndex = JumpTable[needleIndex - 1];
                        }
                        else
                            haystackIndex -= JumpTable[needleIndex];
    
                           
                    }
                }
    
                return NORESULT;
            }
    
            public string Needle
            {
                get { return _needle; }
                set { _needle = value; }
            }
    
            public string Haystack
            {
                get { return _haystack; }
                set { _haystack = value; }
            }
    
            public int[] JumpTable
            {
                get { return _jumpTable; }
                set { _jumpTable = value; }
            }
        }
    }
