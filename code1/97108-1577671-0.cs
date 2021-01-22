	// retrieve a summary of html, with no less than 'max' words
	string GetSummary(string html, int max)
	{
		string summaryHtml = string.Empty;
		// load our html document
		HtmlDocument htmlDoc = new HtmlDocument();
		htmlDoc.LoadHtml(html);
		int wordCount = 0;
		
		foreach (var element in htmlDoc.DocumentNode.ChildNodes)
		{
			// inner text will strip out all html, and give us plain text
			string elementText = element.InnerText;
			// we split by space to get all the words in this element
			string[] elementWords = elementText.Split(new char[] { ' ' });
			// and if we haven't used too many words ...
			if (wordCount <= max)
			{
				// add the *outer* HTML (which will have proper 
				// html formatting for this fragment) to the summary
				summaryHtml += element.OuterHtml;
				wordCount += elementWords.Count() + 1;
			}
			else 
			{ 
				break; 
			}
		}
		return summaryHtml;
	}
