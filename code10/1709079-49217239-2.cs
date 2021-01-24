     try
     {
            SqlConnection connection = new SqlConnection(@"Data Source=USER-PC; Initial Catalog=StudentDB; Integrated Security=True;");
            connection.Open();    
           SqlCommand cmd = new SqlCommand("CREATE TABLE " + txtName.Text + " (LRN int, FirstName nvarchar(50), MiddleName nvarchar(50), LastName nvarchar(50), Gendernvarchar(50), " + txtSub1.Text + " nvarchar(50), " + txtSub2.Text + " nvarchar(50), " + txtSub3.Text + " nvarchar(50), " + txtSub4.Text + " nvarchar(50), " + txtSub5.Text + " nvarchar(50), " + txtSub6.Text + " nvarchar(50), " + txtSub7.Text + " nvarchar(50), Image image, Classification nvarchar(50), Average nvarchar(50), Adviser nvarchar(50), Contact nvarchar(50))", connection);
           cmd.ExecuteNonQuery();
           MessageBox.Show("Table has been created!");
    }
    catch(exception ex)
    {
        MessageBox.Show("error");
    }
