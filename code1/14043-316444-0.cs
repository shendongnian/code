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
        // Doens't work must use English words to add to choices and
        // populate grammar.
        //
        //for (var i = 0; i <= 100; i++)
        //  c.Add(i.ToString());
        c.Add("one");
        c.Add("two");
        c.Add("three");
        c.Add("four");
        // etc...
        var gb = new GrammarBuilder(c);
        var g = new Grammar(gb);
        rec.LoadGrammar(g);
        rec.Enabled = true;
      }
