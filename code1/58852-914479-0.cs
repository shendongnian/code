    StringBuilder sb = new StringBuilder();
    for (int x = 1; x < msglines.Length; x+=2)
    {
        sb.AppendLine(msglines[x]);
    }
    this.textBox5.Text = sb.ToString();
