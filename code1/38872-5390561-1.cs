    private void Form1_Load(object sender, EventArgs e)
    {
        rc.Desc = "hello too";
        car.Desc = "Im a car";
        textBox1.DataBindings.Add("Text", rc, "Desc");
        textBox1.TextChanged .TextChanged += _textBox1_TextChanged;
    }
    
    private void _messagesReceviedLabel_TextChanged(object sender, EventArgs e)
    {
        _textBox1.Text = rc.Desc.ToString();
    }
    
    public class RatesCache : Dictionary<int, Rate>
    {
        public string Desc { get; set; }
    
        public override string ToString()
        {
            return Desc;
        }
    }
