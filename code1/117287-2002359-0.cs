    string masterdin = (@"K:\Drams\Cluse\" +"\\"+"Aia_Gn"+"\\"+Environment.UserName+"\\"+textBox1.Text);
            if(Directory.Exists(masterdin))
            {
                MessageBox.Show("This Export set already exists, please rename your Export set");
                textBox1.Clear();
    
            }
            else 
    System.IO.Directory.CreateDirectory(masterdin);
