    public void CheckListWrapper(ref List<int> list)
    {
        if(list == null)
        { 
            CheckList(out list);
        }
        else
        {
            //append whatever
        }
    }
          
    public void CheckList(out List<int> list)
    {
        if (list == null) {
            list = List<int>();
        }
       //Rest of the code
    }
