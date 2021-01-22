    protected void LoadMyListInBackground(object state)
    {
       List<string> myList = Databse.FetchMyList(myParameters); // This take a while, so the UI thread isn't waiting
    
       ShowMyList(myList);
    }
    
    protected void ShowMyList(List<string> theList)
    {
      if(InvokeRequired)
        Invoke(new Action<List<string>>(ShowMyList, theList);
      else
      {
        foreach(string item in theList)
          myListBox.Items.Add(item);
      }
    }
