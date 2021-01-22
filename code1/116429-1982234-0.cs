    string[] SplitIntoChunks(string text, int size)
    {
        string[] chunk = new string[(text.Length / size) + 1];
        int chunkIdx = 0;
        for (int offset = 0; offset < text.Length; offset += size)
        {
            chunk[chunkIdx++] = text.Substring(offset, size);
        }
        return chunk;
    }    
    
    string[] GetComments()
    {
        var cmtTb = GridView1.Rows[rowIndex].FindControl("txtComments") as TextBox; 
        if (cmtTb == null)
        {
            return new string[] {};
        }
        
        // I assume you don't want to run the text of the two lines together?
        var text = cmtTb.Text.Replace(Environment.Newline, " ");
        return SplitIntoChunks(text, 50);    
    }
