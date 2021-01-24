    void Main()
    {
        List<X> listX;
        List<Y> listY;
        List<Z> listZ;
        using(SqlConnection conn = new SqlConnection())
        {
            conn.Open();
            listX=x.GetParameterListByID(conn, pID);
            listY=y.GetParameterListByID(conn, pID);
            listZ=z.GetParameterListByID(conn, pID);
        }
    }
