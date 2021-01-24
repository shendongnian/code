    public void GetData(object obj, Type objType, string find)
    {
        //as you are passing type of list here, you can use it.
        if(objType == typeof(ABC))
        {
            List<ABC> list = (List<ABC>)obj;
            //now use it.
            //suppose you want list of A1 data
            List<int> a1DataList = new List<int>();
            foreach(ABC abcObj in list)
            {
                a1DataList.Add(abcObj.A1);
            }
        }
    }
