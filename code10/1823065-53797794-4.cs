    public static IList<T> Reverse<T>(MyList<T> list)
    {
        try{   
            list.Reverse = true;
            return list;
        }
        finally{
            ThreadPool.QueueUserWorkItem(delegate{ list.Reverse = false; });
        }
    }
