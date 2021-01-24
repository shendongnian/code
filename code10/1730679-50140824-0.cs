    // Reading all lines of files
    var txtLines =  File.ReadAllLines("your_file_path");
    
    // Make sure, there should be atleast more than one line
    // as you want to get username/password from second line
    if(txtLines != null && txtLines.Count() > 1)
    {
        // Skip first line and after that get first line 
        var secondLine = txtLines.ToList().Skip(1).First();
        // split it by colon
        var splittedText = secondLine.Split(':');
        if(splittedText.Count() > 1)
        {
            Textbox1.Text = splittedText[0];
            Textbox2.Text = splittedText[1];
        }
    }
