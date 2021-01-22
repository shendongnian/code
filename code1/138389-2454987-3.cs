    private void btnUnzip_Click(object sender, System.EventArgs e)
    {
        //Test to see if the user entered a zip file name
        if(txtZipFileName.Text.Trim() == "")
        {
            MessageBox.Show("You must enter what" + 
                   " you want the name of the zip file to be");
            //Change the background color to cue the user to what needs fixed
            txtZipFileName.BackColor = Color.Yellow;
            return;
        }
        else
        {
            //Reset the background color
            txtZipFileName.BackColor = Color.White;
        }
    
        //Launch the zip.exe console app to do the actual zipping
        System.Diagnostics.ProcessStartInfo i =
            new System.Diagnostics.ProcessStartInfo(
            AppDomain.CurrentDomain.BaseDirectory + "zip.exe");
        i.CreateNoWindow = true;
        string args = "";
    
        
        if(txtSource.Text.IndexOf(" ") != -1)
        {
            //we got a space in the path so wrap it in double qoutes
            args += "\"" + txtSource.Text + "\"";
        }
        else
        {
            args += txtSource.Text;
        }
    
        string dest = txtDestination.Text;
    
        if(dest.EndsWith(@"\") == false)
        {
            dest += @"\";
        }
    
        //Make sure the zip file name ends with a zip extension
        if(txtZipFileName.Text.ToUpper().EndsWith(".ZIP") == false)
        {
            txtZipFileName.Text += ".zip";
        }
    
        dest += txtZipFileName.Text;
    
        if(dest.IndexOf(" ") != -1)
        {
            //we got a space in the path so wrap it in double qoutes
            args += " " + "\"" + dest + "\"";
        }
        else
        {
            args += " " + dest;
        }
    
        i.Arguments = args;
        
    
        //Mark the process window as hidden so 
        //that the progress copy window doesn't show
        i.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;    
        System.Diagnostics.Process p = System.Diagnostics.Process.Start(i);
        p.WaitForExit();
        MessageBox.Show("Complete");
    }
