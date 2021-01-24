    protected void Button1_Click(object sender, EventArgs e)
    {
        con = new SqlConnection(cons);
        con.Open();
        string txtb1= TextBox1.Text,
               txtb2= TextBox2.Text;
        sqlCommand.CommandText = "select * from product where name = @name";
        cmd = new SqlCommand("insert into feedback(username,message) values('" + @txtb1 + "','" + @txtb2 +"')", con);
        cmd.Parameters.AddWithValue("txtb1", txtb1);
        cmd.Parameters.AddWithValue("txtb2", txtb2);
        cmd.ExecuteNonQuery();
    }
    
    
 
