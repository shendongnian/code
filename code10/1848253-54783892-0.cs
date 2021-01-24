    protected void Search_Click(object sender, EventArgs e)
    {
        SearchWordDocument searchword = new SearchWordDocument();
		
		var term = SearchField.Text;
        searchword.GetDocumentLibrary(term);
    }
    public class SearchWordDocument 
	{	
		public void GetDocumentLibrary(string searchTerm)
		{
			// use searchTerm
		}
    }
