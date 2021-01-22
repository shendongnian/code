    public class MakeTrans
    {
        private Dictionary<char, char> d = new Dictionary<char, char>();
        public MakeTrans(string intab, string outab)
        {
            for (int i = 0; i < intab.Length; i++)
                d[intab[i]] = outab[i];
        }
        public string Translate(string src)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (char src_c in src)
            {
                char dst_c = d.ContainsKey(src_c) ? d[src_c] : src_c;
                sb.Append(dst_c);
            }
            return sb.ToString();
        }
    }
