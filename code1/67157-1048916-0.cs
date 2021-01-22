    int lineCounter = 0;
    foreach(string line in richTextBox1.Lines)
    {
       //add conditional statement if not selecting all the lines
       richTextBox.Select(richTextBox.GetFirstCharIndexFromLine(lineCounter), line.Length);
       richTextBox.SelectionColor = Color.Red;
       lineCounter++;
    }
