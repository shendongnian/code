    public MyAdapter(Context context, List<string> list)
    {
        this.mContext = context;
        this.mitems = list;
        mList = new List<int>();
        for (int i = 0; i < mitems.Count; i++) {
            mList.Add(0);
        }
    }
