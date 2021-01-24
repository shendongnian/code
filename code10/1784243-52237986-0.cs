    ///Make it as global
    Log F2 = new Log();
    
    public void checkBox4_CheckedChanged(object sender, EventArgs e)
        {           
            if (checkBox4.Checked == true)
            {
    
                F2.Show();
            }
            else if (checkBox4.Checked == false)
            { 
                F2.Close();
                //Here should the exit code be for the Log form.
            }
    }
