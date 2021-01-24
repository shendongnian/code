    public Form1()
    {
    	InitializeComponent();
    
    	richTextBox1.Click += RichTextBox1_Click;
    }
    
    private void RichTextBox1_Click(object sender, EventArgs e)
    {
    	var start = richTextBox1.SelectionStart;
    	
    	int i = 1;
    	string text = richTextBox1.Text;
    	string tokenizingPattern = @"(\[[^][]*]|#[^#]*#)|\s+";
    
    	// Create lookup
    	List<Tuple<string, int, int>> tokenizedWordLookup = new List<Tuple<string, int, int, int>>();
    
    	foreach (Match match in Regex.Matches(text, tokenizingPattern, RegexOptions.Singleline))
    		tokenizedWordLookup.Add(Tuple.Create<string, int, int>(match.Value, i++, match.Index));
    
    	// Return the word index where the selection start is equal to the tokenizing word start
    	return tokenizedWordLookup.Where(x => x.Item3 == richTextBox1.SelectionStart).FirstOrDefault().Item2;
    	
    	labelCurrentWordNumber.Text = tokenizedWordLookup.Where(x => x.Item3 == richTextBox1.SelectionStart).FirstOrDefault().Item2.ToString();
    }
