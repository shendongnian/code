    public void getData(){
    
        using(DBConnect db = new DBConnect()){
            String q = "select * from TestTable";
            SqlCommand cmd = new SqlCommand(q,db.con);
            SqlDatareader r = cmd.ExcecuteReader();
        }
    }
