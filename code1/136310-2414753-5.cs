    private Deck _mainDeck;
    
    public Form1(Deck mainDeck)
    {
        InitializeComponent();
        _mainDeck = mainDeck;
        int Val = _mainDeck.ReturnCard(10);
        textBox1.Text = Val.ToString();
        }
    }
    private void SomeOtherMethod()
    {
        int blah = _mainDeck.Blah();
    }
