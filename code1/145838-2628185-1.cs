    List<string> lines = new List<string>();
    
    int max = 2;
    
    int n = 0;
    
    private void button1_Click(object sender, EventArgs e)
    {
        lines.Insert(0,n.ToString());
       
        richTextBox1.Text = string.Join("\n", lines.Take(max).ToArray<string>());
        n++;
    }
