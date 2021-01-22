    // my search parameters encapsulate all valid ways of searching.
    public class MySearchParameter
    {
        public string FileName { get; private set; }
        public bool FindNullFileNames { get; private set; }
        public void ConditionallySearchFileName(bool getNullFileNames, string fileName)
        {
            FindNullFileNames = getNullFileNames;
            FileName = null;
            // enforce either/or and disallow empty string
            if(!getNullFileNames && !string.IsNullOrEmpty(fileName) )
            {
                FileName = fileName;
            }
        }
        // ...
    }
    // search method in a business logic layer.
    public IQueryable<MyClass> Search(MySearchParameter searchParameter)
    {
        IQueryable<MyClass> result = ...; // something to get the initial list.
        // search on Filename.
        if (searchParameter.FindNullFileNames)
        {
            result = result.Where(o => o.FileName == null);
        }
        else if( searchParameter.FileName != null )
        {   // intermixing a different style, just to show an alternative.
            result = from o in result
                     where o.FileName.Contains(searchParameter.FileName)
                     select o;
        }
        // search on other stuff...
        return result;
    }
    // code in the UI ... 
    MySearchParameter searchParameter = new MySearchParameter();
    searchParameter.ConditionallySearchFileName(chkFileNames.Checked, drpFileNames.SelectedItem.Text);
    searchParameter.ConditionallySearchIPAddress(chkIPAddress.Checked, drpIPAddress.SelectedItem.Text);
    IQueryable<MyClass> result = Search(searchParameter);
    // inform control to display results.
    searchResults.Display( result );
