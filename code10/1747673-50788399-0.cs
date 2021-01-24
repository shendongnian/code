    private int Two;
    private int Three;
    private int sum;
    public Form1()
    {
        this.Two = 0;
        this.Three = 0;
        this.sum = 0;
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
       // MessageBox.Show("Enter the teams` name");
    }
    private void button1_Click(object sender, EventArgs e)
    {
        this.Three += 3;
        sum = textBox3.Text != String.Empty ? Convert.ToInt32(textBox3.Text) : 0;
        textBox3.Text = Convert.ToString(sum + this.Three);
    }
    ... same for number Two
    
    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        textBox3.Text = "0";
    } 
