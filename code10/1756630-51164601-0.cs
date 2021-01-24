    public void Save()
    {
        string insert = "Insert into Professor (fname,lname,dateOfBirth,gender,country,email,mdp) Values(@fname,@lname,@dateOfBirth,@gender,@country,@email,@mdp) ";
        SqlCommand vide = new SqlCommand("Truncate table Professor", mode);
        //Save data from LIST to SERVER
        mode.Open();
        //Truncate the Table
        vide.ExecuteNonQuery();
        //Save All data to SQL
        SqlCommand cmd = new SqlCommand(insert, mode);
        //Add parameters to the command
        cmd.Parameters.Add("@fname", SqlDbType.VarChar);
        cmd.Parameters.Add("@lname", SqlDbType.VarChar);
        cmd.Parameters.Add("@dateOfBirth", SqlDbType.DateTime);
        // Not sure what value you are storing for gender so setting type to VarChar  
        cmd.Parameters.Add("@gender", SqlDbType.VarChar); 
        cmd.Parameters.Add("@country", SqlDbType.VarChar);
        cmd.Parameters.Add("@email", SqlDbType.VarChar);
        cmd.Parameters.Add("@mdp", SqlDbType.VarChar);
        
        //Setting values of parameters and execute the command
        for(int i=0;i<pf.Count;i++)
        {
            cmd.Parameters["@fname"].Value = pf[i].fname;
            cmd.Parameters["@lname"].Value = pf[i].lname;
            cmd.Parameters["@dateOfBirth"].Value = pf[i].dateOfBirth;
            cmd.Parameters["@gender"].Value = pf[i].sexe;
            cmd.Parameters["@country"].Value = pf[i].country;
            cmd.Parameters["@email"].Value = pf[i].email;
            cmd.Parameters["@mdp"].Value = pf[i].password;
            cmd.ExecuteNonQuery();
        }
        mode.Close();
        MessageBox.Show("Your compte has been added!");
    } 
