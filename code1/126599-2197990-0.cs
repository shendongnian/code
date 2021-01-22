    Func<string> del = X;
    del.BeginInvoke(ar => 
    {
        Func<string> endDel = (Func<string>)ar.AsyncState;
        var result = endDel.EndInvoke(ar);
        Console.WriteLine(result);
    }, del);
