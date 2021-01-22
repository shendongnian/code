    class IntegerHolder {
        public IntegerHolder(int x) { i = x; }
        public int i;
    }
    static void AddInc2(Dictionary<string, IntegerHolder> dict, string s)
    {
        IntegerHolder holder = dict[s];
        if (holder != null)
        {
            holder.i++;
        }
        else
        {
            dict.Add(s, new IntegerHolder(1));
        }
    }
