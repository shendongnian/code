    T ElementAt<T>(Stack<T> items, int index)
    {
        var tmp = new Stack<T>();
        while(!items.Empty && index > 0)
        {
           tmp.Push(items.Peek());
           items.Pop();
           index --
        }
        try {
            return items.Peek(); //Presumed to throw an appropriate exception if empty
        }
        finally {
           while(!tmp.Empty)
           {
              items.Push(tmp.Peek());
              tmp.Pop();
           }
        }
    }
