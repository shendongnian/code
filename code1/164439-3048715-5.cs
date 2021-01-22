    string[] myArray = { "foo", "bar", "something", "else", "here" };
    IEnumerator<String> myEnum;
    private string GetNext() //Assumes there will be allways at least 1 element in myArray.
    {
        if(myEnum == null)
           myEnum = myArray.GetEnnumerator();
        if(!myEnum.MoveNext())
        {
           myEnum.Reset();
           myEnum.MoveNext();
        }
        return myEnum.Current;
    }
