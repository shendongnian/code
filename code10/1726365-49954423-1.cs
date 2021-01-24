    string[] filenames;
    
    public Form1()
    {
        InitializeComponent();            
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        //var filenames = Directory.GetFiles("C:/Users/Example/Desktop/folder");
        filenames = Directory.GetFiles(@"C:/Users/Example/Desktop/folder");
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        textBox1.Lines = filenames;
    }
