    void doWork(object data)
    {
        System.Collections.IList list = data as System.Collections.IList;
        if (list != null)
        {
            object[] _objArr = data as object[];
            foreach (object io in list)
            {
                System.Diagnostics.Trace.WriteLine(io);
            }
        }
        else
        {
            System.Diagnostics.Trace.WriteLine(data);
        }
    }
