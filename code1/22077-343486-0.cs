    void ICollection<DataType>.Add(DataType item)
    {
        throw new NotSupportedException();
    }
    public DataType this[int index]
    {
        get { return InnerList[index]; }
    }
    DataType IList<DataType>.this[int index]
    {
        get { return this[index]; }
        set { throw new NotSupportedException(); }
    }
