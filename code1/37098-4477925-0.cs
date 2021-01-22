    public partial class Form1 : Form
    {
        SpeechRecognizer rec = new SpeechRecognizer();
        public Form1()
        {
            InitializeComponent();
            rec.SpeechRecognized += rec_SpeechRecognized;
        }
        void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            lblLetter.Text = e.Result.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var c = new Choices();
            c.Add("one");
            c.Add("two");
            c.Add("three");
            c.Add("four");
            c.Add("Five");
            c.Add("six");
            c.Add("seven");
            c.Add("eight");
            c.Add("nine");
            c.Add("ten");
            // etc...
            var gb = new GrammarBuilder(c);
            var g = new Grammar(gb);
            rec.LoadGrammar(g);
            rec.Enabled = true;
        }
    }
}
