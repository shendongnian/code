    Int32 index = 0;
    Int32 maxLength = 0;
    
    String[] lines = textBox1.Lines;
    
    for (Int32 i = 0; i < lines.Length; ++i)
    {
        Int32 currLength = lines[i].Length;
        if (currLength > maxLength)
        {
            maxLength = currLength;
            index = i;
        }
    }
    
    MessageBox.Show(String.Format("MAX: {0}", index));
