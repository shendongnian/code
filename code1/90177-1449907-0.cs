        protected void Button2_Click(object sender, EventArgs e)
        {
            string MachineGroupName = TextBox2.Text;
            string MachineGroupDesc = TextBox3.Text;
            int TimeAdded = DateTime.Now.Hour+DateTime.Now.Minute+DateTime.Now.Second;
            
            if (MachineGroupName == "" || MachineGroupDesc == "")
            {
                Label1.Text = ("Please ensure all fields are entered");
                Label1.Visible = true;
            }
            else
            {
                System.Data.SqlClient.SqlConnection dataConnection = new SqlConnection();
                dataConnection.ConnectionString =
                    @"Data Source=JAGMIT-PC\SQLEXPRESS;Initial Catalog=SumooHAgentDB;Integrated Security=True";
                System.Data.SqlClient.SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                //tell the compiler and database that we're using parameters (thus the @first, @last, @nick)  
                dataCommand.CommandText = ("INSERT [MachineGroups] ([MachineGroupName],[MachineGroupDesc],[TimeAdded]) VALUES (@MachineGroupName,@MachineGroupDesc,@TimeAdded)");
                //add our parameters to our command object  
                dataCommand.Parameters.AddWithValue("@MachineGroupName", MachineGroupName);
                dataCommand.Parameters.AddWithValue("@MachineGroupDesc", MachineGroupDesc);
                dataCommand.Parameters.AddWithValue("@TimeAdded", TimeAdded);
                dataConnection.Open();
                dataCommand.ExecuteNonQuery();
                dataConnection.Close();
               
            }
