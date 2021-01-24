    public void findIndex(Abc myClass)
    {
        if(myClass.Id == 4)
        {
            //Insert the new item here in the children childs
        }
        else
        {
            Foreach(Abc children in myClass.Child)
            {
                findIndex(children)
            }
        }
    }
