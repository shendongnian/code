    StringBuilder sb = new StringBuilder();
    var st = textBox1.Text.Split('\n');
    for (int i = 0; i < st.Length; i++)
    {
       sb.AppendLine(st[i].Split(':')[0]);
    }
    textBox2.Text = sb.ToString();
