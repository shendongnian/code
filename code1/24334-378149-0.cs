    for (int i = 0; i < MyCollection.Length; i++)
    {
       foreach(MyObjectClass myObject in myObjectCollection)
       {
            if (myObject.Property == MyCollection[i].Property)
            {
                 DoSomethingWith(MyCollection[i]);
                 break;
            }
       }
    }
