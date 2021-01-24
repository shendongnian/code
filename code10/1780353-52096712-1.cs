    void Main()
    {
        List<X> listX;
        List<Y> listY;
        List<Z> listZ;
        using(SqlConnection conn = new SqlConnection())
        {
            conn.Open();
            listX=new X().GetParameterListByID(conn, pID);
            listY=new Y().GetParameterListByID(conn, pID);
            listZ=new Z().GetParameterListByID(conn, pID);
        }
    }
