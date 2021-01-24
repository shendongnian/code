	void Main()
	{
		foreach (var value in GetSynonyms("hot"))
		{
			Debug.WriteLine(value);
		}
	}
	
	public IEnumerable<string> GetSynonyms(string term)
	{
	    var appWord = new Microsoft.Office.Interop.Word.Application();
	    object objLanguage = Microsoft.Office.Interop.Word.WdLanguageID.wdEnglishUS; 
	    Microsoft.Office.Interop.Word.SynonymInfo si = appWord.get_SynonymInfo(term, ref (objLanguage));
	    foreach (var meaning in (si.MeaningList as Array))
		{
			yield return meaning.ToString();
		}
        appWord.Quit(); //include this to ensure the related process (winword.exe) is correctly closed. 
		System.Runtime.InteropServices.Marshal.ReleaseComObject(appWord);
		objLanguage = null;
		appWord = null;
	}
