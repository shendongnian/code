    private void button1_Click(object sender, EventArgs e)
    {
    	using(SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sit\Desktop\25June_LessonEffectivenessAnalysis\LessonEffectivenessAnalysis\LessonEffectivenessAnalysis\LessonEffectivenessAnalysis\LessonAnalysis.mdf;Integrated Security=True");
    	{
    	    conn.Open();
    		using(SqlCommand cmd = new SqlCommand("SELECT PASS, USERID, DISPLAY_NAME, FROM USERS WHERE EMAIL = @MAIL", conn)
    		{
    		    cmd.Parameters.AddWithValue("@MAIL", textBox1.Text);
    			
    			SqlDataReader dr = cmd.ExecuteReader():
    			
    			if(dr.Read()) //We do IF since we only need first one
    			{
    			    //Now we check if typed password is equal to password from database
    			    if(dr[0].ToString().Equals(textBox2.Text))
    				{
    				    this.Hide();
    					Home_Page hp = new Home_Page();
    					hp.Show();
    					
    					
    					//Here we store current user data
    					CurrentUser.userId = Convert.ToInt32(dr[1]);
    					CurrentUser.pass = dr[0].ToString();
    					CurrentUser.displayName = dr[2].ToString();
    					CurrentUser.email = textBox1.Text;
    				}
    				else //Passwords doesn't match
    				{
    				    MessageBox.Show("Wrong password. Try again");
    				}
    			}
    			else //If it hasn't found anyone with that email that mean email is incorect
    			{
    			    MessageBox.Show("E-mail doesn't exist!");
    			}
    		}
    	}
    }
