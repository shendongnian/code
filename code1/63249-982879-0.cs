    public Form1 : Form()
    {
       InitializeComponent();
       this.Load+= (o,e)=>{ this.button1.PerformClick();}
    }
    
    public void button1_Click(object sender, EventArgs e)
    {
       //do what you gotta do
    }
