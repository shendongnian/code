    public Form1()
    {
    	InitializeComponent();
    
    	richTextBox1.Click += RichTextBox1_Click;
    }
    
    private void RichTextBox1_Click(object sender, EventArgs e)
    {
    	var start = richTextBox1.SelectionStart;
    	
    	
    	string text = richTextBox1.Text;
    	string tokenizingPattern = @"(\[[^][]*]|#[^#]*#)|\s+";
    
    	// Create lookup
    	List<Tuple<string, int, int, int>> tokenizedWordLookup = new List<Tuple<string, int, int, int>>();
    
    	int i = 1;
    	foreach (Match match in Regex.Matches(text, tokenizingPattern, RegexOptions.Singleline))
    		tokenizedWordLookup.Add(Tuple.Create<string, int, int, int>(match.Value, i++, match.Index, match.Index + match.Length));
    
    	// Find the word index where the selection start is equal to the tokenizing word start
    	Tuple<string, int, int, int> foundTuple = (tokenizedWordLookup.Where(x => x.Item3 >= start && x.Item4 <= start).FirstOrDefault()) ?? Tuple<string, int, int, int> foundTuple
    	
    	labelCurrentWordNumber.Text = foundTuple.Item2.ToString();
    }
