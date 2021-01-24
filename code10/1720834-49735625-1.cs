    private List<string> list;
    public List<string> Words
    {
        get
        {
            list = list ?? new List<string>();
            return list;
        }
    }
