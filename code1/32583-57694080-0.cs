    // Get only top level windows
	PropertyCondition condition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window);
	AutomationElementCollection windows = AutomationElement.RootElement.FindAll(TreeScope.Children, condition);
	List<AutomationElement> allDocuments = new List<AutomationElement>();
			
	foreach (AutomationElement window in windows)
	{
		string className = window.Current.ClassName;
		if (className == "Notepad" || className == "WordPadClass")
		{
			condition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);
			AutomationElementCollection documents = window.FindAll(TreeScope.Children, condition);
					
			if (documents.Count > 0)
			{
				allDocuments.Add(documents[0]);
			}
		}
	}
	
	// store all pieces of selected text here
	List<string> selectedText = new List<string>();
			
	// iterate through all documents found
	foreach (AutomationElement document in allDocuments)
	{
		object patternObj = null;
		if (document.TryGetCurrentPattern(TextPattern.Pattern, out patternObj) == true)
		{
			TextPattern textPattern = patternObj as TextPattern;
			TextPatternRange[] ranges = textPattern.GetSelection();
					
			foreach (TextPatternRange range in ranges)
			{
				string text = range.GetText(-1);
				if (text.Length > 0)
				{
					selectedText.Add(text);
				}
			}
		}
	}
