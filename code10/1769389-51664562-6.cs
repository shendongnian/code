	public MainWindow()
	{
		InitializeComponent();
		myFlowDocument.Blocks.Add(myParagraph);
		this.Content = myFlowDocument;
		_areas = new Dictionary<string, Func<object[]>>()
		{
			{ "start", () => new object[] { CreateContainer("look") } },
			{ "look", () => new object[] { tStartingAreaLook, CreateContainer("speak"), tStartingAreaLook2, CreateContainer("use"), tStartingAreaLook3 } },
			{ "speak", () => new object[] { tStartingAreaLook, CreateContainer("look"), tStartingAreaLook2, CreateContainer("use"), tStartingAreaLook3 } },
			{ "use", () => new object[] { new Run($"{sUse}"), CreateContainer("start") } },
		};
		
		Starting("start");
	}
	private void Starting(string key)
	{
		foreach (Inline run in myParagraph.Inlines.ToList())
		{
			myParagraph.Inlines.Remove(run);
		}
		foreach (dynamic element in _areas["look"]())
		{
			myParagraph.Inlines.Add(element);
		}
	}
	Paragraph myParagraph = new Paragraph();
	Dictionary<string, Func<object[]>> _areas;
	private ModInlineUIContainer CreateContainer(string text)
	{
		var label = new InlineLabel(text);
		var container = new ModInlineUIContainer(label);
		label.MouseDoubleClick += (s, e) => Starting(text);
		return container;
	}
