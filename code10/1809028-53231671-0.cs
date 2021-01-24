    var s1 = "select email, collegename, cgpa, compname from student_cv 
           where (cgpa >= :x and yearsofexp >= :y) and compname = :z";
    OracleCommand comm = new OracleCommand(s1, conn);
    comm.Parameters.Add("x", OracleType.Number).Value = comboBox1.Text;
    comm.Parameters.Add("y", OracleType.Number).Value = comboBox2.Text;
    comm.Parameters.Add("z", OracleType.VarChar2).Value = "some text";
    
    OracleDataAdapter da = new OracleDataAdapter(comm);
    DataTable dt = new DataTable();
    da.Fill(dt);
    dataGridView1.DataSource = dt;
