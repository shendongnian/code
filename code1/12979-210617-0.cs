    for(int i = 0; i < MyList.Count; i++)
    {
        BaseClass bc = MyList[i];
        ClassA a = bc as ClassA;
        ClassB b = bc as ClassB;
        bc.BaseClassMethod();
        if (a != null) {
           a.PropertyA;
        }
        if (b != null) {
           b.PropertyB;
        }
    }
