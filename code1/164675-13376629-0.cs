    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var strExpression = @"
    import sys
    sys.stdout=my
    print 'ABC' ";
                var engine = Python.CreateEngine();
                var scope = engine.CreateScope();
                var sourceCode = engine.CreateScriptSourceFromString(strExpression);
                scope.SetVariable("my", this);
                var actual = sourceCode.Execute(scope);
                textBox1.Text += actual;
            } catch (System.Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool softspace;
        public void write(string s)
        {
            textBox1.Text += s;
        }
    }
