    async Task<A<BC>> MyTask<A<BC>>(...)
    var abc = await MyTask(...);
    if(abc.Data.IsB)
    {
        var resB = abc.data.ToB();
    }
    else
    {
        var resC = abc.data.ToC();
    }
