    Binding binding1; //binding instance
    public Form1()
    {
        InitializeComponent();
        binding1 = textBox1.DataBindings.Add("Text", this, "FirstName"); //assign binding instance
    }
    
    private void buttonRename_Click(object sender, EventArgs e)
    {
        MessageBox.Show("before: " + FirstName);
        FirstName = "John";
        textBox1.DataBindings.Remove(binding1); //remove binding instance
        binding1 = textBox1.DataBindings.Add("Text", this, "FirstName"); //add new binding
        MessageBox.Show("after: " + FirstName);
    }
