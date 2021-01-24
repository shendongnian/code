    public class TwoArrays
    {
        private string[] _array1 = {"AA01", "AB01", "AB02", "AC02"};
        private string[] _array2 = {"AA00", "AA03", "AA04"};
        public void TryItOut()
        {
            var result = ConcatenateSorted(_array1, _array2);
            var concatenated = string.Join(", ", result);
        }
        private int Compare(string a, string b)
        {
            if (a == b)
            {
                return 0;
            }
            string a1 = a.Substring(0, 2);
            string a2 = a.Substring(2, 2);
            string b1 = b.Substring(0, 2);
            string b2 = b.Substring(2, 2);
            return string.Compare(a2 + a1, b2 + b1);
        }
        private string[] ConcatenateSorted(string[] a, string[] b)
        {
            string[] ret = new string[a.Length + b.Length];
            int aIndex = 0, bIndex = 0, retIndex = 0;
            while (true)    //do this forever, until time to "break" and return
            {
                if (aIndex >= a.Length && bIndex >= b.Length)
                {
                    return ret;
                }
                if (aIndex >= a.Length)
                {
                    ret[retIndex++] = b[bIndex++];
                    continue;
                }
                if (bIndex >= b.Length)
                {
                    ret[retIndex++] = a[aIndex++];
                    continue;
                }
                if (Compare(a[aIndex], b[bIndex]) > 0)
                {
                    ret[retIndex++] = b[bIndex++];
                }
                else
                {
                    ret[retIndex++] = a[aIndex++];
                }
            }
        }
    }
