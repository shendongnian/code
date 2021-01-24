    public void test()
    {
    SqlDataReader datareader = new SqlDataReader;
    while (datareader.read)
    {
        Mydata alldata = new Mydata;
        alldata.Part1 = datareader(1).toString.Split("-")(0);
        alldata.Part2 = datareader(1).toString.Split("-")(1);
    }
    }
