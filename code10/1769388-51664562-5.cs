		public MainWindow()
		{
			InitializeComponent();
			StartingArea();
			myFlowDocument.Blocks.Add(myParagraph);
			this.Content = myFlowDocument;
		}
	
		Paragraph myParagraph = new Paragraph();
	
		private ModInlineUIContainer CreateContainer(string text, Action mouseDoubleClick)
		{
			var label = new InlineLabel(text);
			var container = new ModInlineUIContainer(label);
			
			label.MouseDoubleClick += (s, e) => mouseDoubleClick();
			
			return container;
		}
		
		public void StartingArea()
		{
			ClearParagraph();
			var look = CreateContainer("look", () => StartingAreaLook());
			AddInline(tStartingText, look);
		}
	
		void StartingAreaLook()
		{
			ClearParagraph();
			var speak = CreateContainer("speak", () => StartingAreaSpeak());
			var use = CreateContainer("use", () => StartingAreaUse());
			AddInline(tStartingAreaLook, speak, tStartingAreaLook2, use, tStartingAreaLook3);
		}
	
		void StartingAreaSpeak()
		{
			ClearParagraph();
			var look = CreateContainer("look", () => StartingAreaLook());
			var use = CreateContainer("use", () => StartingAreaUse());
			AddInline(tStartingAreaSpeak, look, tStartingAreaSpeak2, use, tStartingAreaSpeak3);
		}
		
		void StartingAreaUse()
		{
			ClearParagraph();
			var tStartingArea_Use = new Run($"{sUse}");
			var restart = CreateContainer("Restart", () => StartingArea());
			AddInline(tStartingArea_Use, restart);
		}
		
		void ClearParagraph()
		{
			foreach (Inline run in myParagraph.Inlines.ToList())
			{
				myParagraph.Inlines.Remove(run);
			}
		}
	
		public void AddInline(params object[] inline)
		{
			foreach (dynamic element in inline)
			{
				myParagraph.Inlines.Add(element);
			}
		}
