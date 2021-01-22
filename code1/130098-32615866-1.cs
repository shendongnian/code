    private bool Status = false;
    SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
    Choices dic = new Choices(new String[] {
                "word1",
                "word2",
                });
    public Form1()
    {
        InitializeComponent();
        Grammar gmr = new Grammar(new GrammarBuilder(dic));
        gmr.Name = "myGMR";
        // My Dic
        sre.LoadGrammar(gmr);
      sre.SpeechRecognized += 
      new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        sre.SetInputToDefaultAudioDevice();
        sre.RecognizeAsync(RecognizeMode.Multiple);
    } 
    private void button1_Click(object sender, EventArgs e)
    {
        if (Status)
        {
            button1.Text = "START";
            Status = false;
            stslable.Text = "Stopped";
        }
        else {
            button1.Text = "STOP";
            Status = true;
            stslable.Text = "Started";
        }
    }
    public void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs ev)
    {
       String theText = ev.Result.Text;
      MessageBox.Show(theText);
    }
