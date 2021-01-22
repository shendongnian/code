    static void Main()
    {
        List<string> myList = new List<string> { "Jason", "Bob", "Frank", "Bob" };
        myList.RemoveAll(x => x == "Bob");
        foreach (string s in myList)
        {
            //
        }
    }
