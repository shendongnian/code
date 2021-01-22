    private object _mainDeck;
    
    public Form1(object mainDeck)
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
