    void NewDictionary(Dictionary<string,int> dict)
    {
       dict = new Dictionary<string,int>(); // Just changes the local reference
    }
    void  ClearDictionary(Dictionary<string,int> dict)
    {
       dict.Clear();
    }
    // When you use this...
    Dictionary<string,int> myDictionary = ...; // Set up and fill dictionary
    NewDictionary(myDictionary);
    // myDictionary is unchanged here, since we made a new copy, but didn't change the original instance
    ClearDictionary(myDictionary);
    // myDictionary is now empty
