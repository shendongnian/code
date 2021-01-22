    public static List<string> PermuteWords(string s)
        {
            string[] ss = s.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            bool[] used = new bool[ss.Length];
            string res = "";
            List<string> list = new List<string>();
            permute(ss, used, res, 0, list);
            return list;
        }
        private static void permute(string[] ss, bool[] used, string res, int level, List<string> list)
        {
            if (level == ss.Length && res != "")
            {
                list.Add(res);
                return;
            }
            for (int i = 0; i < ss.Length; i++)
            {
                if (used[i]) continue;
                used[i] = true;
                permute(ss, used, res + " " + ss[i], level + 1, list);
                used[i] = false;
            }
        }
