    public Form1()
    {
        InitializeComponent();
    
        
        acsc = new AutoCompleteStringCollection();
        textBox1.AutoCompleteCustomSource = acsc;
        textBox1.AutoCompleteMode = AutoCompleteMode.None;
        textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        acsc.Add("[001] some kind of item");
        acsc.Add("[002] some other item");
        acsc.Add("[003] an orange");
        acsc.Add("[004] i like pickles");
    }
    
    void textBox1_TextChanged(object sender, System.EventArgs e)
    {
        listBox1.Items.Clear();
        if (textBox1.Text.Length == 0)
        {
        hideResults();
        return;
        }
    
        foreach (String s in textBox1.AutoCompleteCustomSource)
        {
        if (s.Contains(textBox1.Text))
        {
            Console.WriteLine("Found text in: " + s);
            listBox1.Items.Add(s);
            listBox1.Visible = true;
        }
        }
    }
    
    void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString();
        hideResults();
    }
    
    void listBox1_LostFocus(object sender, System.EventArgs e)
    {
        hideResults();
    }
    
    void hideResults()
    {
        listBox1.Visible = false;
    }
