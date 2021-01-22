    protected void Page_Load(object sender, EventArgs e)
            {
                SqlConnection connection = new SqlConnection("server = Saher;Database=Database.mdf;integrated security = true");
                try{
                    connection.Open();
                }
                catch(Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }finally{
                    connection.Close();
                }
    
            }
