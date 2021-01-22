This preserves order and, based on my tests, is 4 times faster than using a HashSet.  This assumes your character range is 0-255 but you can extend that easily.  If you're planning on using this in a loop, move the int[] c = new int[255]; out and in the function do an Array.Clear(c,0,255).
        private static string RemoveDuplicates(string s)
        {
            int[] c = new int[255];
            for (int i = 0; i &lt; s.Length; i++)
            {
                c[s[i]]++;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i &lt; s.Length; i++)
            {
                if (c[s[i]] == 1) sb.Append(s[i]);
            }
            return sb.ToString();
        }
