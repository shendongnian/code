    for (int i=0; i<MyCollection.Count; i++)
    {
        var a = i;
        Task.Factory.StartNew(()=>
        {
            DoStuffWith(MyCollection[a]);
            DoEvenMoreStuffWith(MyCollection[a]);
        });
    }
