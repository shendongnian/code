    //this exists at the **class** level, outside of a function
    private List<string> inputList = new List<string>();
    private void button1_Click(object sender, EventArgs e)
    {
        addToList(textBox1.Text);
    }
    public  void addToList(string word)
    {
        inputList.Add(word);
        inputList.Sort();
        label1.Text = string.Join(Environment.NewLine, inputList);
    }
