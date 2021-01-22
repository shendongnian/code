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
    
      void Form1_Load(object sender, EventArgs e)
      {
        var c = new Choices();
        for (var i = 0; i <= 100; i++)
          c.Add(i.ToString());
        var gb = new GrammarBuilder(c);
        var g = new Grammar(gb);
        rec.LoadGrammar(g);
        rec.Enabled = true;
      }
