    public static SelectList SelectIfOnlyOneItem(this SelectList list)
    {
       if (list.Count() == 1) 
       { 
           list= new SelectList(list.ToList(), "Value", "Text", list.Single().Value)
       }
       return list;
    }
