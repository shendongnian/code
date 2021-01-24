    foreach (var item in collection)
    {
        if (item.Contains("some text"))
        {
            removeNext = true;
            myList.Add(item);
        }
        else if (!(item.ToUpper().Contains("TEXT IN UPPER") | item.Contains("some other text")))
        {
            if (!removeNext)
                myList.Add(item);
            removeNext = false;
        }
    }
