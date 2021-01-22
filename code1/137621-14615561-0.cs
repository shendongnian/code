    Regex wordEx = new Regex(@"[A-Za-z]", RegexOptions.Compiled);
    MatchCollection mcol = wordEx.Matches(webEditor.Document.Body.InnerHtml);
     
    foreach (Match m in mcol)
    {
      //Basic checking for whether this word is an HTML tag. This is not perfect.
      if (m.Value == e.Word && webEditor.Document.Body.InnerHtml.Substring(m.Index -1, 1) != "<")
      {
        wordIndeces.Add(m.Index);
      }
    }
             
    foreach (int curWordTextIndex in wordIndeces)
    {
       Word word = Word.GetWordFromPosition(webEditor.Document.Body.InnerHtml, curWordTextIndex);
       string tmpText = webEditor.Document.Body.InnerHtml.Remove(word.Start, word.Length);
       webEditor.Document.Body.InnerHtml = tmpText.Insert(word.Start, e.NewWord);
    }
      
    UpdateSpellingForm(e.TextIndex);
