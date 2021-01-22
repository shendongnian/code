    FirstEntityType first = new FirstEntityType();
    first.Id = 2;
    List<SecondType> list = CreateList(); //Let's say this returns a List with 10 elements
    context.FirstEntityType.AddObject(first);
    for (int i = 0; i < list.Count; i++)
    {
        list[i].First = first;
    }
    //just for arguments sake a second for
    for (int i = 0; i < list.Count; i++)
    {
        context.SecondType.AddObject(list);
    }
    
    context.SaveChanges();
