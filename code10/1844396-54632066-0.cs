    private string _currentTableName; // or reference list item directly
    // use this pseudo code to create "Previous" method as well 
    void NextButtonPressed(object sender, EventArgs e)
    {
        // Get current element using stored name
        if(string.IsNullOrEmpty(_currentTableName))
        {
            _currentTableName = firstElement.Name;
            // show first
            Display(firstElement);
        }
        else 
        {
             // get current element 
             // get next element
             _currentTableName = nextElement.Name;
             Display(nextElement);
        }
    }
