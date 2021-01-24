    public void findIndex(Abc myClass)
    {
        Foreach(Abc children in myClass.Child)
        {
           if(children.Id == 4)
           {
               //Insert the new item here in the children childs
           }
           else
           {
               findIndex(children.Child)
           }
        }
    }
