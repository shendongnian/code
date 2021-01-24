    // Gets all string file paths in a folder
    // then grabs the first one, or null if there are none
    string filePath = Directory.GetFiles(@"C:\TwinTable\LeftTableO0201", "*.*").FirstOrDefault();
    // if the path is not null, empty or whitespace    
    if(!string.IsNullOrWhiteSpace(filePath)
    {
        // then get the filename and put it in the textbox
        TboxLeftTable.Text = Path.GetFileName(filePath);
    }
    else
    {
        // There were no files in the folder so make the textbox empty
        TboxLeftTable.Text = string.Empty;
    }
