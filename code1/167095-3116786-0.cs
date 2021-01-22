    protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=E:\ChurchApp\ChurchApplication\App_Data\Database.mdf;Integrated Security=True;User Instance=True");
            try{
                connection.Open();
                lblMessage.Text = "Connection Succeeded!";
            }
            catch(Exception ex){
                lblMessage.Text = ex.Message;
            }finally{
                connection.Close();
            }
            
    
    
        }
