    private void SplitStrings()
    {
        List<string> listValues = (List<string>) Session["mylist"];
    
        // always check session values for null
        if(listValues != null)
        {
            // go through each list item
            foreach(string stringElement in listValues)
            {
                 // do something with variable 'stringElement'
                 System.Console.WriteLine(stringElement);
            }
        }
    }
