    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog f = new OpenFileDialog();
       
        f.ShowDialog();                 
        ListBox l = new ListBox();
        l.Items.Add("one");
        l.Items.Add("two");
        l.Items.Add("three");
        l.Items.Add("four");
        string textout = "";
        // assume the li is a string - will fail if not
        foreach (string li in l.Items)
        {
            textout = textout + li + Environment.NewLine;
        }
        textout = "extra stuff at the top" + Environment.NewLine + textout + "extra stuff at the bottom";
        File.WriteAllText(f.FileName, textout);
        MessageBox.Show("all saved!");
    }
