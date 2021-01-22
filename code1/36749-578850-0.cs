        int line = 0;
        foreach (string file in myfiles)
        {
            // Whatever method you want to choose a color, here
            // I'm just alternating between red and blue
            richTextBox1.SelectionColor = 
                line % 2 == 0 ? Color.Red : Color.Blue;
            // AppendText is better than rtb.Text += ...
            richTextBox1.AppendText(file + "\r\n");
            line++;
        }
