    int numRows;
    bool success = int.TryParse(textBox1.text, out numRows); // lets say textBox1 contains number of rows.
    if(success)
    {
        for(int i = 0; i < numRows; i++)
        {
            AddRow();
        }
    }
