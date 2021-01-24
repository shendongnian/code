    ///Make it as global
    Log F2 = null;
    
    public void checkBox4_CheckedChanged(object sender, EventArgs e)
        {      
               F2=new Log();     
            if (checkBox4.Checked == true)
            {   
    
                F2.Show();
            }
            else if (checkBox4.Checked == false)
            { 
                F2.Hide();
                F2.Close();
                //Here should the exit code be for the Log form.
            }
    }
