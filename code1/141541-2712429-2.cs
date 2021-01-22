    public partial class Form1 : Form 
    { 
       DateTime TimeTypingBegan { get; set; }
    
       public Form1() 
       { 
          InitializeComponent(); 
       }
    
       private void textBox1_TextChanged(object sender, EventArgs e) 
       {
          if (textBox1.Text.Length == 1)
             TimeTypingBegan = DateTime.Now;
          else if (textBox1.Text.Length == 10)
             label1.Text = (DateTime.Now - TimeTypingBegan).ToString();
       } 
    }
