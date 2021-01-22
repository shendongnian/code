    using (var erator = enumerable.GetEnumerator())
    {
        if (erator.MoveNext())
        {
            DoActionOnFirst(erator.Current);
    
            while (erator.MoveNext())
                DoActionOnOther(erator.Current);
        }
    }
