    IEnumerable<O> Reduce<I,O>(this IEnumerable<I> source, Func<I,Tuple<bool, O>> transform )
    {
        foreach (var item in source)
        {
           try
           {
              Result<O> r = transform(item);
              if (r.success) yield return r.value;
           }
           catch {}
        }
    }
    ReadLines().Reduce(l => { var i; new Tuple<bool, int>(int.TryParse(l.Substring(3,3),i), i)} );
