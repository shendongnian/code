    string fileName1 ="authentication.txt";
    string curPass = "someDefaultPass";
    if(System.IO.File.Exists(fileName1)
        curPass = System.IO.File.ReadAllText(fileName1);
    if(textBox1.Text == curPass)
    {
        Hide();
    }
    else{
        MessageBox.Show("Yikes. That's incorrect.", "Uh oh.");
    }
