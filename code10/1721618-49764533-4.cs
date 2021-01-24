    public IEnumerable<string> ZipNames(IEnumerable<string> firsts, 
        IEnumerable<string> middles, IEnumerable<string> lasts) 
    {
        using(var e1 = firsts.GetEnumerator())
        using(var e2 = middles.GetEnumerator())
        using(var e3 = lasts.GetEnumerator())
        {
            var stop = false;
            while (!stop)
            {
                var hasNext1 = e1.MoveNext();
                var hasNext2 = e2.MoveNext();
                var hasNext3 = e3.MoveNext();
            
                if (hasNext1 && hasNext2 && hasNext3) 
                {
                    yield return $"{e1.Current} {e2.Current} {e3.Current}";
                }
                else
                {
                    stop = true;
                    Debug.Assert(!(hasNext1 || hasNext2 || hasNext3));
                }
            }
        }
    }
